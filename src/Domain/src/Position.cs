using System.Diagnostics;
using System.Runtime.InteropServices;

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
    public float Quantity { get; init; }
    public decimal Entry { get; init; }
    public DateTime EntryAt { get; init; }
    public decimal Exit { get; private set; }
    public DateTime ExitAt { get; private set; }
    public PositionStatus Status { get; private set; }
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
    public decimal PnL
    {
        get { return Status == PositionStatus.Open ? 0 : (Exit - Entry) * (decimal)Quantity; }
    }
    public bool IsWin
    {
        get { return PnL > 0; }
    }

    public Position(Symbol symbol, PositionType type, float quantity, decimal entry, DateTime entryAt, string? id = null, decimal? exit = null, DateTime? exitAt = null)
    {
        Id = id ?? Guid.NewGuid().ToString();
        Symbol = symbol;
        Type = type;
        Quantity = quantity;
        Entry = entry;
        EntryAt = entryAt;
        if (exit != null) Exit = (decimal)exit;
        if (exitAt != null) ExitAt = (DateTime)exitAt;
        Status = (exit == null && exitAt == null) ? PositionStatus.Open : PositionStatus.Close;
    }

    public void Close(decimal exitPrice, DateTime exitDate)
    {
        if (Status == PositionStatus.Close)
            return;

        Status = PositionStatus.Close;
        Exit = exitPrice;
        ExitAt = exitDate;
        OnClosed?.Invoke(this);
        OnClosed = null;
    }
}
