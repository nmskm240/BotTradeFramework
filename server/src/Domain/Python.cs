using System;

using Python.Runtime;

namespace BotTrade.Domain;

public static class Python
{
    private static readonly IPyObjectDecoder[] _decoders =
    [
        new DictionaryConverter<int>(),
        new DictionaryConverter<double>(),
    ];
    private static readonly IPyObjectEncoder[] _encoders =
    [
        new DictionaryConverter<int>(),
        new DictionaryConverter<double>(),
    ];

    public static void Setup()
    {
        const string PYTHON_HOME = "/root/.pyenv/versions/3.10.15";
        Runtime.PythonDLL = $"{PYTHON_HOME}/lib/libpython3.10.so";
        var pythonPath = string.Join(
            Path.PathSeparator.ToString(),
            [
                PythonEngine.PythonPath,
                $"{PYTHON_HOME}/lib/python3.10/site-packages"
            ]
        );
        Environment.SetEnvironmentVariable("PYTHONHOME", PYTHON_HOME, EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable("PYTHONPATH", pythonPath, EnvironmentVariableTarget.Process);

        foreach(var decoder in _decoders)
            PyObjectConversions.RegisterDecoder(decoder);

        foreach(var encoder in _encoders)
            PyObjectConversions.RegisterEncoder(encoder);

        PythonEngine.Initialize();
        PythonEngine.BeginAllowThreads();
    }
}

#region Converters
internal class DictionaryConverter<T> : IPyObjectDecoder, IPyObjectEncoder
    where T : struct
{
    public bool CanDecode(PyType objectType, Type targetType)
    {
        return objectType.ToString() == "dict" && targetType == typeof(Dictionary<string, T>);
    }

    public bool CanEncode(Type type)
    {
        return type == typeof(Dictionary<string, T>);
    }

    public bool TryDecode<S>(PyObject pyObj, out S? value)
    {
        value = default;

        if(!CanDecode(pyObj.GetPythonType(), typeof(S)))
            return false;

        var result = new Dictionary<string, T>();
        using var dict = new PyDict(pyObj);
        foreach(var key in dict.Keys())
        {
            var v = dict[key];
            result[key.As<string>()] = (T)v!.AsManagedObject(typeof(T));
        }
        value = (S?)(object)result;
        return true;
    }

    public PyObject? TryEncode(object value)
    {
        if (value is not Dictionary<string, T> dictionary)
            return null;

        var dict = new PyDict();
        foreach(var pair in dictionary)
        {
            dict[pair.Key] = pair.Value.ToPython();
        }

        return dict;
    }
}
#endregion
