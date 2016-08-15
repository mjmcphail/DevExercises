using Autofac;
using q6.Implementations;
using q6.Interfaces;
using RS.Common.Interfaces;

namespace q6
{
    /// <summary>
    /// Q6 Application Autofac Module
    /// Autofac modules are a great way to 
    /// segregate registration code from the rest of the code
    /// and also provide alot of flexibility for DI
    /// </summary>
    public class Q6AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register our concrete types as interfaces with Autofac
            builder.RegisterType<Q6Application>().As<IApplication>();
            builder.RegisterType<BinaryTreeFactory>().As<IBinaryTreeFactory>();
            builder.RegisterType<TreeComparer>().As<ITreeComparer>();
        }
    }
}
