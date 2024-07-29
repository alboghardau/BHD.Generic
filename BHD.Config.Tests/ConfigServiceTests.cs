using BHD.Config.Models;
using BHD.Config.Services;
using Newtonsoft.Json.Linq;

namespace BHD.Config.Tests
{
    public class ConfigServiceTests
    {

        private ConfigService _configService;
        private ConfigFile _configFile;

        public ConfigServiceTests()
        {
            _configFile = new ConfigFile();
            _configService = new ConfigService(_configFile);
        }

        [Fact]
        public void GetBool_ShouldReturnTrue_WhenValueIsTrue()
        {
            // Arrange
            _configFile.Configuration = JObject.Parse("{\"Setting\": true}");

            // Act
            var result = _configService.GetBool("$.Setting");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetBool_ShouldReturnFalse_WhenValueIsFalse()
        {
            // Arrange
            _configFile.Configuration = JObject.Parse("{\"Setting\": false}");

            // Act
            var result = _configService.GetBool("$.Setting");

            // Assert
            Assert.False(result);
        }
    }
}