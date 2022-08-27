using BHD.Config;

namespace BHD.ConfigTests;

public class ConfigManagerTests
{
    ConfigManager config = ConfigManager.Instance;

    [Fact]
    public void TestLoadConfig()
    {
        ConfigManager config = ConfigManager.Instance;
        Assert.True(config.LoadConfigurationByFileName("Config.json"));        
    }

    [Fact]
    public void TestGetInt()
    {
        config.LoadConfigurationByFileName("Config.json");
        int prop = config.GetInt("intProp");
        Assert.True(prop == 5);
    }

    [Fact]
    public void TestGetString()
    {
        config.LoadConfigurationByFileName("Config.json");
        string prop = config.GetString("stringProp");
        Assert.True(prop == "test");
    }

    [Fact]
    public void TestGetBool()
    {
        config.LoadConfigurationByFileName("Config.json");
        bool prop = config.GetBool("boolProp");
        Assert.True(prop == true);
    }
}
