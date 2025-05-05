using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime;

public class SaveLoad
{
    public static void SaveJSON(GameData data, string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".jsn";

        Debug.Log(path);

        GameDataToken token = new GameDataToken(data);
        string save = JsonUtility.ToJson(token, true);
        File.WriteAllText(path, save);
    }

    public static GameDataToken LoadJSON(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".jsn";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameDataToken token = JsonUtility.FromJson<GameDataToken>(json);
            return token;
        }
        else
        {
            return null;
        }
    }



}
