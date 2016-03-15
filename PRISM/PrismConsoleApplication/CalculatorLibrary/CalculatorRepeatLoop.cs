namespace CalculatorLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CalculatorCommandParsingLibrary;
    using InterfacesLibrary;

    public class CalculatorRepeatLoop : ICalculatorRepeatLoop
    {
        private IInputService inputService;

        private IOutputService outputService;

        private ICalculator calculator;

        private IInputParserService inputParserService;

        public CalculatorRepeatLoop(
            ICalculator calculator,
            IInputService inputService,
            IOutputService outputService,
            IInputParserService inputParserService)
        {
            this.Calculator = calculator;
            this.InputParserService = inputParserService;
            this.InputService = inputService;
            this.OutputService = outputService;
        }

        public IInputService InputService
        {
            get
            {
                return this.inputService;
            }
            set
            {
                this.inputService = value;
            }
        }

        public IOutputService OutputService
        {
            get
            {
                return this.outputService;
            }
            set
            {
                this.outputService = value;
            }
        }

        public ICalculator Calculator
        {
            get
            {
                return this.calculator;
            }
            set
            {
                this.calculator = value;
            }
        }

        public IInputParserService InputParserService
        {
            get
            {
                return this.inputParserService;
            }
            set
            {
                this.inputParserService = value;
            }
        }

        public void Run()
        {
            while (true)
            {
                string command = this.InputService.ReadCommand();
                try
                {
                    var commandType = this.InputParserService.ParseCommandTypes(command);
                    var args = this.InputService.ReadArguments();
                    this.OutputService.WriteMessage(this.Calculator.Execute(commandType, args).ToString());
                }
                catch (Exception)
                {
                    Console.WriteLine("Mistake");
                }
            }
        }
    }
}
