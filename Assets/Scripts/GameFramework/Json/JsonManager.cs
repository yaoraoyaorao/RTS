using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public enum JsonType
{
    JsonUtlity,
    LitJson
}
/// <summary>
/// Json的数据管理类，主要进行Json的序列化和反序列化
/// </summary>
public class JsonManager
{
    private static JsonManager instance = new JsonManager();

    public static JsonManager Instance => instance;
    private JsonManager() { }

    /// <summary>
    /// 存储json数据 序列化
    /// </summary>
    /// <param name="data">要存储的对象</param>
    /// <param name="fileName">文件名</param>
    /// <param name="jsonType">要存储的json类型</param>
    public void SaveData(object data,string fileName,JsonType jsonType = JsonType.LitJson)
    {
        //确定存储路径
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        //序列化得到Json字符串
        string jsonStr = "";
        switch (jsonType)
        {
            case JsonType.JsonUtlity:
                jsonStr = JsonUtility.ToJson(data);
                break;
            case JsonType.LitJson:
                jsonStr = JsonMapper.ToJson(data);
                break;
        }
        File.WriteAllText(path, jsonStr);
    }

    /// <summary>
    /// 读取指定文件中的json数据 反序列化
    /// </summary>
    /// <typeparam name="T">对象</typeparam>
    /// <param name="fileName">文件名</param>
    /// <param name="type">读取json的类型</param>
    /// <returns></returns>
    public T LoadData<T>(string fileName,JsonType type = JsonType.LitJson)where T:new()
    {
        //确定那条路径读取
        //首先判断默认数据文件夹中是否有我们想要的数据，如果有，就从中获取
        string path = Application.streamingAssetsPath + "/" + fileName + ".json";
        if(!File.Exists(path))
            path = Application.persistentDataPath + "/" + fileName + ".json";
        if (!File.Exists(path))
            return new T();
        string jsonStr = File.ReadAllText(path);
        T data = default(T);
        switch (type)
        {
            case JsonType.JsonUtlity:
                data = JsonUtility.FromJson<T>(jsonStr);
                break;
            case JsonType.LitJson:
                data = JsonMapper.ToObject<T>(jsonStr);
                break;
        }
        return data;
    }
}
