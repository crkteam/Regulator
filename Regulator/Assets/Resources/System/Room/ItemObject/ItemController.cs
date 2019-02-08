using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public GameObject block;
    public Image button_block;
    public Text content_ui;
    
    public delegate void ItemHandler();

    private String[] group_buffer;

    public event ItemHandler dialogueEnd;

    private int count, end;

    // String
    public String[] content;

    public void startDialogue(TextAsset item, int group)
    {
        content = item.text.Split('\n');
        block.SetActive(true);
        button_block.enabled = true;
        group_buffer = content[1].Split(';');
        
        setGroup(group);
        content_ui.text = content[count];
        InvokeRepeating("click",0,0.3f);
    }

    void click()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            nextLine();
        }
    }

    void setGroup(int group)
    {
        String[] buffer = group_buffer[group].Split(',');
        count = int.Parse(buffer[0]) - 1;
        end = int.Parse(buffer[1]) - 1;
    }

    void nextLine()
    {
        count++;
        
    }

    void clear()
    {
        count = 0;
        end = 0;
        content = null;
    }
}