using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Dialogur
{
    private StreamReader file;
    private int count = 1;
    List<string> data = new List<string>();
    List<string> character = new List<string>();


    public Dialogur(string name)
    {
        string buffer;

        file = new StreamReader(Path.Combine(Application.absoluteURL + "dialogue/" + "Lobby", name));

        while ((buffer = file.ReadLine()) != null)
        {
            data.Add(buffer);
        }

        setname();
    }

    private void setname()
    {
        string[] name = data[0].Split(';');

        for (int i = 0; i < name.Length; i++)
        {
            character.Add(name[i]);
        }
    }

    public int gethead()
    {
        return int.Parse(data[count].Split(':')[0]);
    }

    public string getText()
    {
        string[] content = data[count].Split(':');
        int name = int.Parse(content[0]);
        string buffer = character[name] + ":" + content[1];

        return buffer;
    }

    public void NextLine()
    {
        count++;
    }

    public bool check()
    {
        if (count != data.Count)
            return true;

        return false;
    }
}