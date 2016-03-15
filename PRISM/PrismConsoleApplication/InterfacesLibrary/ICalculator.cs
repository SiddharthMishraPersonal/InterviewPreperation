namespace InterfacesLibrary
{
    using CommonTypesLibrary;

    public interface ICalculator
    {
        int Execute(CommandTypes commandType, Arguments args);

        int Add(Arguments args);

        int Substract(Arguments args);

        int Multiply(Arguments args);

        int Divide(Arguments args);
    }
}