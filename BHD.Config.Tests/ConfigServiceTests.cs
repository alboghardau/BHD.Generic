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

        #region LoadFile Tests
        [Fact]
        public void LoadConfigurationByFileName_ShouldLoadConfig_WhenFileExists()
        {
            // Arrange
            var configFileContent = "{\"Setting\": \"Value\"}";
            var configFilePath = Path.Combine(AppContext.BaseDirectory, "Config.json");
            File.WriteAllText(configFilePath, configFileContent);

            // Act
            var result = _configService.LoadConfigurationByFileName("Config.json");

            // Assert
            Assert.True(result);
            Assert.NotNull(_configFile.Configuration);
            Assert.Equal("Value", _configFile.Configuration["Setting"].ToString());

            // Cleanup
            File.Delete(configFilePath);
        }

        [Fact]
        public void LoadConfigurationByPath_ShouldLoadConfig_WhenFileExists()
        {
            // Arrange
            var configFileContent = "{\"Setting\": \"Value\"}";
            var configFilePath = Path.Combine(AppContext.BaseDirectory, "Config.json");
            File.WriteAllText(configFilePath, configFileContent);

            // Act
            var result = _configService.LoadConfigurationByPath(configFilePath);

            // Assert
            Assert.True(result);
            Assert.NotNull(_configFile.Configuration);
            Assert.Equal("Value", _configFile.Configuration["Setting"].ToString());

            // Cleanup
            File.Delete(configFilePath);
        }

        [Fact]
        public void LoadConfigurationByPath_ShouldReturnFalse_WhenFileDoesNotExist()
        {
            var result = _configService.LoadConfigurationByPath("NonExistentConfig.json");

            Assert.False(result);
        }
        #endregion

        #region GetBool Tests
        [Fact]
        public void GetBool_ShouldReturnTrue_WhenValueIsTrue()
        {
            _configFile.Configuration = JObject.Parse("{\"Setting\": true}");

            var result = _configService.GetBool("$.Setting");

            Assert.True(result);
        }

        [Fact]
        public void GetBool_ShouldReturnFalse_WhenValueIsFalse()
        {
            _configFile.Configuration = JObject.Parse("{\"Setting\": false}");

            var result = _configService.GetBool("$.Setting");

            Assert.False(result);
        }

        [Fact]
        public void GetBool_ShuoldReturnFalse_WhenValueIsNull()
        {
            _configFile.Configuration = JObject.Parse("{\"Settings\": null}");

            var result = _configService.GetBool("$.Setting");

            Assert.False(result);
        }
        #endregion

        #region GetInt Tests
        [Fact]
        public void GetInt_ShouldReturnIntegerValue_WhenValueIsValidInteger()
        {
            // Arrange
            _configFile.Configuration = JObject.Parse("{\"Setting\": 123}");

            // Act
            var result = _configService.GetInt("$.Setting");

            // Assert
            Assert.Equal(123, result);
        }

        [Fact]
        public void GetInt_ShouldReturnZero_WhenValueIsNotValidInteger()
        {
            // Arrange
            _configFile.Configuration = JObject.Parse("{\"Setting\": \"abc\"}");

            // Act
            var result = _configService.GetInt("$.Setting");

            // Assert
            Assert.Equal(0, result);
        }
        #endregion

        #region GetString Tests
        [Fact]
        public void GetString_ShouldReturnStringValue()
        {
            // Arrange
            _configFile.Configuration = JObject.Parse("{\"Setting\": \"Value\"}");

            // Act
            var result = _configService.GetString("$.Setting");

            // Assert
            Assert.Equal("Value", result);
        }

        [Fact]
        public void ReadValue_ShouldReturnEmptyString_WhenPathIsInvalid()
        {
            // Arrange
            _configFile.Configuration = JObject.Parse("{\"Setting\": \"Value\"}");

            // Act
            var result = _configService.GetString("$.InvalidSetting");

            // Assert
            Assert.Equal(string.Empty, result);
        }
        #endregion
    }
}