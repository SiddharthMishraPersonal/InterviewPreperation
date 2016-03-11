namespace InterfacesLibrary
{
    using CommonTypesLibrary;

    public interface IInputService
    {
        string ReadCommand();

        Arguments ReadArguments();
    }
}