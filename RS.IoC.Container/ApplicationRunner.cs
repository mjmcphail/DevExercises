using System;
using System.IO;
using Autofac;
using Autofac.Core;
using RS.Common.Interfaces;

namespace RS.IoC.Registration
{
    /// <summary>
    /// This class provides a generic way for all apps to 
    /// run, building up dependencies through autofac 
    /// and registering the application specific modules
    /// It also handles command line parameters and 
    /// running the application logic
    /// </summary>
    public static class ApplicationRunner 
    {
        public static void RunApplication(string[] args, IModule autoFacModule)
        {
            if (args.Length > 0)
            {
                //initialize a new IoC container builder
                var iocBuilder = new IoCBuilder();

                //register our module into the IoC container builder
                iocBuilder.RegisterModule(autoFacModule);

                //build up our components
                iocBuilder.Build();

                //use a lifetime scope so things get cleaned up when 
                //we are done with the IoC container
                using (var scope = IoCBuilder.Container.BeginLifetimeScope())
                {
                    //service locator pattern... anti pattern to DI but
                    //I am unaware of a way to inject IQ4Application
                    //into the constructor of the console main entry point
                    var application = scope.Resolve<IApplication>(
                        new NamedParameter("fileName", args[0]));

                    try
                    {
                        //run the app
                        application.Run();
                    }
                    catch (FileNotFoundException)
                    {
                        //catch the only exception that should be thrown 
                        //by the application - show friendly message to user
                        Console.WriteLine("Unable to open the file specified.  Please verify file exists.");
                    }
                }
            }
            else
            {
                //user did not specify a file name on command line so show 
                //a friendly message.
                Console.WriteLine("Please specify a filename on the command line.");
            }
        }
    }
}
