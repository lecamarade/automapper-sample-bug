using AutoFixture;
using MyAutoMapperSample.Eight;
using MyAutoMapperSample.Model;

var config = MyAutomMapperConfiguration.GetConfiguration();
config.AssertConfigurationIsValid();

var user = new Fixture().Create<User>();

var mapper = new AutoMapper.Mapper(config);
var properties = mapper. DefaultContext.Mapper.Map<User, UserPropertiesContainer>(user);

Console.WriteLine($"{properties.UserStoreId}");
Console.WriteLine("I'm AutoMapper 8 and I'm happy!");