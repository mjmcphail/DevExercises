using RS.IoC.Registration;

namespace q4
{
    class Program
    {
        static void Main(string[] args)
        {
            //This runs our application
            //The class declaration for this class is located at
            //RS.IoC.Registration
            ApplicationRunner.RunApplication(args, new q4AutoFacModule());
        }
    }
}
