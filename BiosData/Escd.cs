using System.Text.Json;
using Data;

namespace BiosData;

public class Escd : IBiosData
{
    private const string DefaultProductName = "Lenovo L340-15API";
    private const string DefaultBiosVersion = "0.001";
    private const string DefaultEcVersion = "N2CHT26W";
    private const string DefaultMtm = "81LW";
    private const string DefaultSerial = "SN8BDE6606";
    private const string DefaultCpu = "AMD Ryzen 5 2600x Six-Core Processor";
    private const int DefaultRam = 16384;

    public string ProductName { get; set; }
    public string BiosVersion { get; set; }
    public string EcVersion { get; set; }
    public string Mtm { get; set; }
    public string Serial { get; set; }
    public string Uuid { get; set; }
    public string Cpu { get; set; }
    public int Ram { get; set; }

    private readonly IJsonHandler _handler;

    public Escd(IJsonHandler handler)
    {
        _handler = handler;
        SetDefault();
    }


    public void Load()
    {
        var data = _handler.Load();
        if (data != null)
        {
            ProductName = (string)data["ProductName"];
            BiosVersion = (string)data["BiosVersion"];
            EcVersion = (string)data["EcVersion"];
            Mtm = (string)data["Mtm"];
            Serial = (string)data["Serial"];
            Uuid = (string)data["Uuid"];
            Cpu = (string)data["Cpu"];
            Ram = (int)data["Ram"];
        }
    }

    public void Save()
    {
        var data = new Dictionary<string, object>
        {
            ["ProductName"] = ProductName,
            ["BiosVersion"] = BiosVersion,
            ["EcVersion"] = EcVersion,
            ["Mtm"] = Mtm,
            ["Serial"] = Serial,
            ["Uuid"] = Uuid,
            ["Cpu"] = Cpu,
            ["Ram"] = Ram
        };
        
        _handler.Save(data);
    }

    public void SetDefault()
    {
        ProductName = DefaultProductName;
        BiosVersion = DefaultBiosVersion;
        EcVersion = DefaultEcVersion;
        Mtm = DefaultMtm;
        Serial = DefaultSerial;
        Uuid = Guid.NewGuid().ToString();
        Cpu = DefaultCpu;
        Ram = DefaultRam;
    }
}