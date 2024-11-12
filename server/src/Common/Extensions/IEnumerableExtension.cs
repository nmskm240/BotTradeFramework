namespace BotTrade;

// TODO: あまりにごり押し過ぎるからいい感じにリファクトしたい

public static class IEnumerableExtentsion
{
    public static IEnumerable<Result> Combination<Result, Source, Arg>(
        this IEnumerable<Source> source,
        IEnumerable<Arg> args,
        Func<Source, Arg, Result> converter)
    {
        foreach (var s in source)
        {
            foreach (var arg in args)
            {
                yield return converter(s, arg);
            }
        }
    }

    public static IEnumerable<Result> Combination<Result, Source, Arg1, Arg2>(
        this IEnumerable<Source> source,
        IEnumerable<Arg1> args1,
        IEnumerable<Arg2> args2,
        Func<Source, Arg1, Arg2, Result> converter)
    {
        foreach (var s in source)
        {
            foreach (var a1 in args1)
            {
                foreach (var a2 in args2)
                {
                    yield return converter(s, a1, a2);
                }
            }
        }
    }

    public static IEnumerable<Result> Combination<Result, Source, Arg1, Arg2, Arg3>(
        this IEnumerable<Source> source,
        IEnumerable<Arg1> args1,
        IEnumerable<Arg2> args2,
        IEnumerable<Arg3> args3,
        Func<Source, Arg1, Arg2, Arg3, Result> converter)
    {
        foreach (var s in source)
        {
            foreach (var a1 in args1)
            {
                foreach (var a2 in args2)
                {
                    foreach (var a3 in args3)
                    {
                        yield return converter(s, a1, a2, a3);
                    }
                }
            }
        }
    }

    public static IEnumerable<Result> Combination<Result, Source, Arg1, Arg2, Arg3, Arg4>(
        this IEnumerable<Source> source,
        IEnumerable<Arg1> args1,
        IEnumerable<Arg2> args2,
        IEnumerable<Arg3> args3,
        IEnumerable<Arg4> args4,
        Func<Source, Arg1, Arg2, Arg3, Arg4, Result> converter)
    {
        foreach (var s in source)
        {
            foreach (var a1 in args1)
            {
                foreach (var a2 in args2)
                {
                    foreach (var a3 in args3)
                    {
                        foreach (var a4 in args4)
                        {
                            yield return converter(s, a1, a2, a3, a4);
                        }
                    }
                }
            }
        }
    }

    public static IEnumerable<Result> Combination<Result, Source, Arg1, Arg2, Arg3, Arg4, Arg5>(
        this IEnumerable<Source> source,
        IEnumerable<Arg1> args1,
        IEnumerable<Arg2> args2,
        IEnumerable<Arg3> args3,
        IEnumerable<Arg4> args4,
        IEnumerable<Arg5> args5,
        Func<Source, Arg1, Arg2, Arg3, Arg4, Arg5, Result> converter)
    {
        foreach (var s in source)
        {
            foreach (var a1 in args1)
            {
                foreach (var a2 in args2)
                {
                    foreach (var a3 in args3)
                    {
                        foreach (var a4 in args4)
                        {
                            foreach (var a5 in args5)
                            {
                                yield return converter(s, a1, a2, a3, a4, a5);
                            }
                        }
                    }
                }
            }
        }
    }
}

