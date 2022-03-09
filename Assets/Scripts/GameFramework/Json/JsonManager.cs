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
/// Json�����ݹ����࣬��Ҫ����Json�����л��ͷ����л�
/// </summary>
public class JsonManager
{
    private static JsonManager instance = new JsonManager();

    public static JsonManager Instance => instance;
    private JsonManager() { }

    /// <summary>
    /// �洢json���� ���л�
    /// </summary>
    /// <param name="data">Ҫ�洢�Ķ���</param>
    /// <param name="fileName">�ļ���</param>
    /// <param name="jsonType">Ҫ�洢��json����</param>
    public void SaveData(object data,string fileName,JsonType jsonType = JsonType.LitJson)
    {
        //ȷ���洢·��
        string path = Application.persistentDataPath + "/" + fileName + ".json";
        //���л��õ�Json�ַ���
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
    /// ��ȡָ���ļ��е�json���� �����л�
    /// </summary>
    /// <typeparam name="T">����</typeparam>
    /// <param name="fileName">�ļ���</param>
    /// <param name="type">��ȡjson������</param>
    /// <returns></returns>
    public T LoadData<T>(string fileName,JsonType type = JsonType.LitJson)where T:new()
    {
        //ȷ������·����ȡ
        //�����ж�Ĭ�������ļ������Ƿ���������Ҫ�����ݣ�����У��ʹ��л�ȡ
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
