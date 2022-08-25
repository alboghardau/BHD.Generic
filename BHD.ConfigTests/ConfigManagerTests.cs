using MServ.Auth.Config;

namespace BHD.ConfigTests;

public class ConfigManagerTests
{
    ConfigManager config = ConfigManager.Instance;

    [Fact]
    public void TestLoadConfig()
    {
        ConfigManager config = ConfigManager.Instance;
        Assert.True(config.LoadConfiguration("Config.json"));        
    }

    [Fact]
    public void TestGetInt()
    {
        config.LoadConfiguration("Config.json");
        int prop = config.GetInt("intProp");
        Assert.True(prop == 5);
    }

    [Fact]
    public void TestGetString()
    {
        config.LoadConfiguration("Config.json");
        string prop = config.GetString("stringProp");
        Assert.True(prop == "test");
    }

    [Fact]
    public void TestGetBool()
    {
        config.LoadConfiguration("Config.json");
        bool prop = config.GetBool("boolProp");
        Assert.True(prop == true);
    }
}
