using Autofac;
using q5.Implementations;
using q5.Interfaces;
using RS.Common.Interfaces;

namespace q5
{
    /// <summary>
    /// Q5 Application Autofac Module
    /// Autofac modules are a great way to 
    /// segregate registration code from the rest of the code
    /// and also provide alot of flexibility for DI
    /// </summary>
    public class Q5AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register our concrete types as interfaces with Autofac
            builder.RegisterType<Q5Application>().As<IApplication>();
            builder.RegisterType<MatrixDataLoader>().As<IMatrixDataLoader>();
            builder.RegisterType<SpiralArrayFactory>().As<ISpiralArrayFactory>();
        }
    }
}
