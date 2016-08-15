using RS.IoC.Registration;

namespace q6
{
    class Program
    {
        static void Main(string[] args)
        {
            //This runs our application
            //The class declaration for this class is located at
            //RS.IoC.Registration
            ApplicationRunner.RunApplication(args, new Q6AutoFacModule());
        }
    }
}
