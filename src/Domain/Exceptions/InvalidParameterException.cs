namespace BotTrade.Domain.Exceptions;

internal class InvalidParameterException : Exception
{
    internal InvalidParameterException(string message)
     : base(message)
    {
    }

    public override string ToString()
    {
        return Message;
    }
}
