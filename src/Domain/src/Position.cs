namespace BotTrade.Domain;

public enum PositionStatus
{
    Open,
    Close,
}

public enum PositionType
{
    Long,
    Short,
}

public class Position
{
    public string Id { get; init; }
    public Symbol Symbol { get; init; }
    public PositionType Type { get; init; }
    public decimal Quantity { get; init; }
    public decimal Entry { get; init; }
    public decimal Exit { get; private set; }
    public PositionStatus Status { get; private set; } = PositionStatus.Open;

    public Position(Symbol symbol, PositionType type, decimal quantity, decimal entry)
    {
        Id = Guid.NewGuid().ToString();
        Symbol = symbol;
        Type= type;
        Quantity = quantity;
        Entry = entry;
    }

    public void Close(decimal exitPrice)
    {
        Status = PositionStatus.Close;
        Exit = exitPrice;
    }

    /// <summary>
    /// ポジション損益
    /// </summary>
    /// <remarks>
    /// <c>currentPrice</c>を省略した場合、未決済のポジションは損益0とする
    /// </remarks>
    /// <param name="currentPrice">現在の価格</param>
    /// <returns></returns>
    public decimal Result(decimal currentPrice = 0)
    {
        if(Status == PositionStatus.Open)
            return (currentPrice - Entry) * Quantity;

        return (Exit - Entry) * Quantity;
    }
}