﻿using System.Text.Json;
using System.Text.Json.Serialization;
using ZRQ.Utils.ClassTemplate;

namespace ZRQ.Utils.Config;

public static class JsonConfigStatic
{
    public static readonly JsonSerializerOptions Options = GetJsonSerializerOptions();

    public static JsonSerializerOptions GetJsonSerializerOptions()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,                   // 测试对齐
            PropertyNameCaseInsensitive = true,     // 不区分大小写的属性名称
        };
        return options;
    }
}

public class JsonConfig<T> where T : JsonConfig<T>, new()
{
    [JsonIgnore]
    protected virtual string JsonFile { get; set; } = Path.Combine(Environment.CurrentDirectory, $"{nameof(T)}.json");

    private static T? _inst;

    public static T Inst
    {
        get
        {
            if (_inst != null) return _inst;

            _inst = new T();
            LoadConfig(_inst);
            return _inst;
        }
    }

    private static void LoadConfig(T inst)
    {
        try
        {
            var jsonFile = inst.JsonFile;
            if (!File.Exists(jsonFile)) return;

            string jsonString = File.ReadAllText(jsonFile);

            T? deserialize = JsonSerializer.Deserialize<T>(jsonString);
            if (deserialize != null)
            {
                inst = deserialize;
            }
        }
        catch (Exception)
        {
            // ignored
        }
    }

    public void Save()
    {
        var options = JsonConfigStatic.Options;
        //byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(this);

        string jsonString = JsonSerializer.Serialize(Inst, options);
        File.WriteAllText(JsonFile, jsonString);
    }

    public async Task SaveAsync()
    {
        var options = JsonConfigStatic.Options;
        await using FileStream createStream = File.Create(JsonFile);
        {
            //byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(this);
            await JsonSerializer.SerializeAsync(createStream, this, options);
            await createStream.DisposeAsync();
        }
    }
}

