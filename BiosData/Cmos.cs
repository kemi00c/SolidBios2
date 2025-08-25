using Data;

namespace BiosData;

public class Cmos : IBiosData
{
    private const string Enabled = "Enabled";
    private const string Disabled = "Disabled";

    private const string DefaultSecureBoot = Enabled;
    private const string DefaultWlan = Enabled;
    private const string DefaultPowerBeep = Disabled;
    private const string DefaultHwVm = Disabled;
    private const string DefaultPerformanceMode = "Performance";
    private const string DefaultBootMode = "UEFI";
    private const string DefaultUsbBoot = Enabled;
    private const string DefaultPxeBootToLan = Enabled;
    private const string DefaultIpV4PxeFirst = Enabled;
    private const string DefaultOsOptimizedDefaults = Enabled;

    public string SecureBoot { get; set; }
    public string Wlan { get; set; }
    public string PowerBeep { get; set; }
    public string HwVm { get; set; }
    public string PerformanceMode { get; set; }
    public string AdminPassword { get; set; }
    public string UserPassword { get; set; }
    public string BootMode { get; set; }
    public string UsbBoot { get; set; }
    public string PxeBootToLan { get; set; }
    public string IpV4PxeFirst { get; set; }
    public string OsOptimizedDefaults { get; set; }

    private readonly IJsonHandler _handler;

    public Cmos(IJsonHandler handler)
    {
        _handler = handler;
        SetDefault();
    }


    public void Load()
    {
        var data = _handler.Load();
        SecureBoot = (string)data["SecureBoot"];
        Wlan = (string)data["Wlan"];
        PowerBeep = (string)data["PowerBeep"];
        HwVm = (string)data["HwVm"];
        PerformanceMode = (string)data["PerformanceMode"];
        AdminPassword = (string)data["AdminPassword"];
        UserPassword = (string)data["UserPassword"];
        BootMode = (string)data["BootMode"];
        UsbBoot = (string)data["UsbBoot"];
        PxeBootToLan = (string)data["PxeBootToLan"];
        IpV4PxeFirst = (string)data["IpV4PxeFirst"];
        OsOptimizedDefaults = (string)data["OsOptimizedDefaults"];
    }

    public void Save()
    {
        var data = new Dictionary<string, object>
        {
            ["SecureBoot"] = SecureBoot,
            ["Wlan"] = Wlan,
            ["PowerBeep"] = PowerBeep,
            ["HwVm"] = HwVm,
            ["PerformanceMode"] = PerformanceMode,
            ["AdminPassword"] = AdminPassword,
            ["UserPassword"] = UserPassword,
            ["BootMode"] = BootMode,
            ["UsbBoot"] = UsbBoot,
            ["PxeBootToLan"] = PxeBootToLan,
            ["IpV4PxeFirst"] = IpV4PxeFirst,
            ["OsOptimizedDefaults"] = OsOptimizedDefaults,
        };
        _handler.Save(data);
    }

    public void SetDefault()
    {
        SecureBoot = DefaultSecureBoot;
        Wlan = DefaultWlan;
        PowerBeep = DefaultPowerBeep;
        HwVm = DefaultHwVm;
        PerformanceMode = DefaultPerformanceMode;
        AdminPassword = string.Empty;
        UserPassword = string.Empty;
        BootMode = DefaultBootMode;
        UsbBoot = DefaultUsbBoot;
        PxeBootToLan = DefaultPxeBootToLan;
        IpV4PxeFirst = DefaultIpV4PxeFirst;
        OsOptimizedDefaults = DefaultOsOptimizedDefaults;
    }
}