using Autofac;
using Autofac.Core;
using RS.Common.Implementations;

namespace RS.IoC.Registration
{
    /// <summary>
    /// This class provides a simple
    /// facade in front of the Autofac IoC
    /// container to make it a little easier 
    /// to work with and so consuming classes
    /// do not have to worry about some of the details
    /// of Autofac
    /// </summary>
    public class IoCBuilder
    {
        public static IContainer Container { get; private set; }

        private readonly ContainerBuilder _builder;

        public IoCBuilder()
        {
            _builder = new ContainerBuilder();
            RegisterCommon();
        }

        /// <summary>
        /// Provides a way to register an Autofac module
        /// - use this BEFORE you do a build
        /// </summary>
        /// <param name="module"></param>
        public void RegisterModule(IModule module)
        {
            _builder.RegisterModule(module);
        }

        /// <summary>
        /// Register all classes that are part
        /// of the common assembly as they 
        /// will be used in all projects
        /// </summary>
        private void RegisterCommon()
        {
            var commonAssembly = typeof(FileFacade).Assembly;
            _builder.RegisterAssemblyModules(commonAssembly);
        }

        /// <summary>
        /// Build the container and resolve dependencies
        /// - once this is done it cannot be undone so 
        /// make sure you have registered all components
        /// and modules before you call the build function
        /// </summary>
        public void Build()
        {
            Container = _builder.Build();
        }
    }
}
