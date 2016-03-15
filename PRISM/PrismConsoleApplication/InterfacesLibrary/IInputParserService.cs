namespace InterfacesLibrary
{
    using CommonTypesLibrary;

    public interface IInputParserService
    {
        CommandTypes ParseCommandTypes(string command);
    }
}