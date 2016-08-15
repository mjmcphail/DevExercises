using Autofac;
using RS.Common.Interfaces;

namespace RS.Common.Implementations
{
    public class CommonAutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileFacade>().As<IFileFacade>();
        }
    }
}
