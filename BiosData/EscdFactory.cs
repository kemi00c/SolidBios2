using Autofac;
using Data;

namespace BiosData;

public class EscdFactory
{
    private readonly string _filepath = "escd.json";
    private readonly IContainer _container;
    private static Escd? _escd;

    public EscdFactory()
    {
        var builder = new ContainerBuilder();
        builder.RegisterInstance(new JsonHandler(_filepath)).As<IJsonHandler>();
        _container = builder.Build();
    }

    public Escd? Get()
    {
        if (_escd == null)
        {
            var jsonHandler = _container.Resolve<IJsonHandler>();
            _escd = new Escd(jsonHandler);
        }
        
        return _escd;
    }
}