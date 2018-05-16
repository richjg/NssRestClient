﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    internal static class StringExtensions
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        public static string ToJson(this object content) => JsonConvert.SerializeObject(content, JsonSerializerSettings);
        public static T FromJson<T>(this string json) => JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings);
        public static async Task<T> FromJsonAsync<T>(this Task<string> jsonTask) => (await jsonTask).FromJson<T>();
    }
}
