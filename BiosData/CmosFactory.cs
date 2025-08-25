using Autofac;
using Data;

namespace BiosData;

public class CmosFactory
{
    private readonly string _filePath = "cmos.json";
    private readonly IContainer _container;
    private static Cmos? _cmos;
    
    
    public CmosFactory()
    {
        var builder = new ContainerBuilder();
        builder.RegisterInstance(new JsonHandler(_filePath)).As<IJsonHandler>();
        _container = builder.Build();
    }

    public Cmos? Get()
    {
        if (_cmos == null)
        {
            var jsonHandler = _container.Resolve<IJsonHandler>();
            _cmos = new Cmos(jsonHandler);
        }
        
        return _cmos;
    }
}