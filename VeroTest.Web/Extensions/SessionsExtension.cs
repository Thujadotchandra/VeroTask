﻿using Microsoft.AspNetCore.Http;
using System.Text.Json;

public static class SessionExtension
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.Set(key, JsonSerializer.SerializeToUtf8Bytes(value));
    }

    public static T Get<T>(this ISession session, string key)
    {
        var value = session.Get(key);

        return value == null ? default(T) :
            JsonSerializer.Deserialize<T>(value);
    }
}