// See https://aka.ms/new-console-template for more information
using FourthPharos.Domain.CandelaObscuraCircle;
using FourthPharos.Domain.CandelaObscuraCircle.Models;
using FourthPharos.Domain.CandelaObscuraCircle.Operations;
using FourthPharos.Persistence;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

// use CosmosDB emulator: https://learn.microsoft.com/en-us/azure/cosmos-db/local-emulator?tabs=ssl-netstd21
// add connection string to user secrets under "CosmosDb:ConnectionString"

var c = CircleFactory.CreateCirle("Circle of the Crimson Tear")
    .AddAbility(CircleAbility.StaminaTraining)
    .AddGear("Bleed Detector")
    .AddIllumination(10)
    .SetLocation("The Weeping House")
    .ConsumeResource(CircleResource.Stitch)
    .ConsumeStaminaDice();

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

using var client = new CosmosClient(
    connectionString: configuration["CosmosDb:ConnectionString"],
    clientOptions: new() { SerializerOptions = new() { PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase } });

var circleContainer = client.GetContainer("fourth-pharos", "circles");

var writeModel = CircleMapper.ToStorageModel(c);
await circleContainer.CreateItemAsync(writeModel);

var readResult = await circleContainer.ReadItemAsync<CircleStorageReadModel>(c.Id.ToString("D"), new(c.OwnerId.ToString("D")));
var readModel = CircleMapper.FromStorageModel(readResult.Resource);

Console.WriteLine(readModel);
