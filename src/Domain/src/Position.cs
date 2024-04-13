using System.Diagnostics;

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
    public DateTime EntryDate { get; init; }
    public decimal Exit { get; private set; }
    public DateTime ExitDate { get; private set; }
    public PositionStatus Status { get; private set; } = PositionStatus.Open;
    /// <summary>
    /// ポジションが閉じられたときに通知される
    /// </summary>
    /// <remarks>
    /// 一度通知すると<c>null</c>になる
    /// </remarks>
    public event Action<Position>? OnClosed;
    /// <summary>
    /// ポジション利益
    /// </summary>
    public decimal Profit
    {
        get { return Status == PositionStatus.Open ? 0 : (Exit - Entry) * Quantity; }
    }

    public Position(Symbol symbol, PositionType type, decimal quantity, decimal entry, DateTime entryDate)
    {
        Id = Guid.NewGuid().ToString();
        Symbol = symbol;
        Type = type;
        Quantity = quantity;
        Entry = entry;
        EntryDate = entryDate;
    }

    public void Close(decimal exitPrice, DateTime exitDate)
    {
        Debug.Assert(Status == PositionStatus.Open);

        Status = PositionStatus.Close;
        Exit = exitPrice;
        ExitDate = exitDate;
        OnClosed?.Invoke(this);
        OnClosed = null;
    }
}
