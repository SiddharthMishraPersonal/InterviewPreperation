namespace PrismConsoleApplication
{
    using InterfacesLibrary;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System.Configuration;
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            //container.RegisterType<ICalculatorRepeatLoop, CalculatorRepeatLoop>();
            //container.RegisterType<ICalculator, Calculator>();
            //container.RegisterType<IInputService, ConsoleInputService>();
            //container.RegisterType<IOutputService, ConsoleOutputService>();
            //container.RegisterType<IInputParserService, InputParserService>();

            var configurationSection = (UnityConfigurationSection)ConfigurationManager.GetSection("Unity");
            configurationSection.Configure(container);

            var loop = container.Resolve<ICalculatorRepeatLoop>();

            loop.Run();
        }
    }
}
