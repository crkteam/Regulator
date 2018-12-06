using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContorller
{
    private int count;
    private string content;
    private List<string> charater;
    private List<string> contentline;

    private string[] sentence;

    public DialogueContorller(string name) //Need to add path
    {
        count = 1;
        content = Resources.Load<TextAsset>(name).text;
        sentence = new string[2];
        contentline = new List<string>();
        charater = new List<string>();

        init();
    }

    public bool check()
    {
        if (count == contentline.Count)
            return false;
        else
            return true;
    }

    public string getName()
    {
        return sentence[0];
    }

    public string getContent()
    {
        return sentence[1];
    }

    public string getSentence()
    {
        return sentence[0] + ":" + sentence[1];
    }

    private void keyContent()
    {
        foreach (string line in content.Split('\n'))
        {
            contentline.Add(line);
        }
    }

    private void setCharater()
    {
        foreach (string buffer in contentline[0].Split(';'))
        {
            charater.Add(buffer);
        }
    }

    public void nextLine()
    {
        string[] buffer = contentline[count].Split(':');
       
        sentence[0] = charater[int.Parse(buffer[0])];
        sentence[1] = buffer[1];
        count++;
    }

    private void init()
    {
        keyContent();
        setCharater();
        nextLine();
    }

}