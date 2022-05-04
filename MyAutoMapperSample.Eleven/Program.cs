using AutoFixture;
using MyAutoMapperSample.Eleven;
using MyAutoMapperSample.Model;

var config = MyAutomMapperConfiguration.GetConfiguration();
config.AssertConfigurationIsValid();

var user = new Fixture().Create<User>();

var mapper = new AutoMapper.Mapper(config);
Console.WriteLine("I'm AutoMapper 11 and I'm NOT happy!");


var properties = mapper.Map<User, UserPropertiesContainer>(user);
Console.WriteLine($"{properties.UserStoreId}");
