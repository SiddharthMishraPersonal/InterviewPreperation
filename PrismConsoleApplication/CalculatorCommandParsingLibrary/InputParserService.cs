using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCommandParsingLibrary
{
    using CommonTypesLibrary;

    using InterfacesLibrary;

    public class InputParserService : IInputParserService
    {
        public CommandTypes ParseCommandTypes(string command)
        {
            return ((CommandTypes)Enum.Parse(typeof(CommandTypes), command));
        }
    }
}
