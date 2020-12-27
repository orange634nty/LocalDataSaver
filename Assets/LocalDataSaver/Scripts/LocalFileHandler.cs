using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace LocalDataSaver
{
    public static class LocalFileHandler<T>
    {
        /// <summary>
        /// get file path and name by class name
        /// </summary>
        private static string FilePath => $"{Application.persistentDataPath}/{typeof(T).Name}.json";

        /// <summary>
        /// Load data from local storage
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T Load()
        {
            if (!File.Exists(FilePath)) throw new Exception($"file: {FilePath} not exist");
            var rawJson = File.ReadAllText(FilePath, Encoding.UTF8);
            return JsonUtility.FromJson<T>(rawJson);
        }

        /// <summary>
        /// Save data from local storage
        /// </summary>
        /// <param name="data">data object which save to local storage</param>
        /// <returns></returns>
        public static void Save(object data)
        {
            var rawJson = JsonUtility.ToJson(data, true);
            File.WriteAllText(FilePath, rawJson, Encoding.UTF8);
        }
    }
}
