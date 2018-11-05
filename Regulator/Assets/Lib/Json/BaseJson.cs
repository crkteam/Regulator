

using System.IO;
using UnityEngine;

public class BaseJson
{
    protected void save(object data, string name)
    {
        StreamWriter file = new StreamWriter(Path.Combine(Application.absoluteURL, name));
        string saveString = JsonUtility.ToJson(data);
        file.Write(saveString);
        file.Close();
    }

    protected string load(string name)
    {
        StreamReader file = new StreamReader(Path.Combine(Application.absoluteURL, name));
        string loadJson = file.ReadToEnd();
        file.Close();

        return loadJson;
    }

    protected bool check(string name)
    {
        try {
            StreamReader file = new StreamReader(Path.Combine(Application.absoluteURL, name));
        }catch(FileNotFoundException e) {
            Debug.Log(e.Message);
            return false;
        }

        return true;
    }
}