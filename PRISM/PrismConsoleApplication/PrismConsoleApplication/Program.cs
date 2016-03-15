namespace PrismConsoleApplication
{
    using CalculatorCommandParsingLibrary;

    using CalculatorLibrary;

    using InterfacesLibrary;

    using Microsoft.Practices.Unity;

    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<ICalculatorRepeatLoop, CalculatorRepeatLoop>();
            container.RegisterType<ICalculator, Calculator>();
            container.RegisterType<IInputService, ConsoleInputService>();
            container.RegisterType<IOutputService, ConsoleOutputService>();
            container.RegisterType<IInputParserService, InputParserService>();

            var loop = container.Resolve<ICalculatorRepeatLoop>();
            
            loop.Run();
        }
    }
}
