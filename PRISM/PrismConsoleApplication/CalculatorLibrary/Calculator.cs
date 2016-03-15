using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    using CommonTypesLibrary;

    using InterfacesLibrary;

    public class Calculator : ICalculator
    {
        public int Execute(CommandTypes commandType, Arguments args)
        {
            switch (commandType)
            {
                case CommandTypes.Add:
                    return this.Add(args);

                case CommandTypes.Subtract:
                    return this.Substract(args);

                case CommandTypes.Multiply:
                    return this.Multiply(args);

                case CommandTypes.Divide:
                    return this.Divide(args);

                default: throw new InvalidOperationException();

            }
        }

        public int Add(Arguments args)
        {
            return (args.X + args.Y);
        }

        public int Substract(Arguments args)
        {
            return (args.X - args.Y);
        }

        public int Multiply(Arguments args)
        {
            return (args.X * args.Y);
        }

        public int Divide(Arguments args)
        {
            return (args.X / args.Y);
        }
    }
}
