using Autofac;
using q4.Implementations;
using q4.Interfaces;
using RS.Common.Interfaces;

namespace q4
{
    /// <summary>
    /// Q4 Application Autofac Module
    /// Autofac modules are a great way to 
    /// segregate registration code from the rest of the code
    /// and also provide alot of flexibility for DI
    /// </summary>
    public class q4AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register our concrete types as interfaces with Autofac
            builder.RegisterType<Q4Application>().As<IApplication>();
            builder.RegisterType<WhitespaceRemover>().As<IWhitespaceRemover>();
            builder.RegisterType<DuplicateCharRemover>().As<IDuplicateCharRemover>();
        }
    }
}
