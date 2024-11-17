namespace BotTrade.Domain;

public readonly record struct Symbol
{
    public string Code { get; init; }
    public string Name { get; init; }
    public ExchangePlace Place { get; init; }

    public Symbol(string code, string name, ExchangePlace place)
    {
        Code = code;
        Name = name;
        Place = place;
    }
}
