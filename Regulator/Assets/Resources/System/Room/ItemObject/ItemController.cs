using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public GameObject block, condition;
    public Image button_block;
    public Text content_ui,B1,B2;

    public delegate void ItemHandler();

    private String[] group_buffer, name_buffer;

    public event ItemHandler dialogueEnd;

    private int count, end, context_count;
    //mutiple
    private int m_switch;
    // String
    public String[] content;

    private void Update()
    {
        if (m_switch > 0)
        {
            m_switch = 0;
            CancelInvoke("click");
        }
    }

    public void startDialogue(TextAsset item, int group)
    {
        m_switch = 0;
        context_count = 0;
        content = item.text.Split('\n');
        block.SetActive(true);
        button_block.enabled = true;
        group_buffer = content[1].Split(';');

        setGroup(group);
        setName();
        nextLine();
        InvokeRepeating("click", 0, 0.1f);
    }

    void click()
    {
        if (context_count < 11)
            context_count++;

        if (context_count > 10)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                context_count = 0;
                nextLine();
            }
        }
    }

    void setGroup(int group)
    {
        String[] buffer = group_buffer[group].Split(',');
        count = int.Parse(buffer[0]) - 1;
        end = int.Parse(buffer[1]) - 1;
    }

    void setName()
    {
        string[] buffer = content[0].Split(';');
        name_buffer = new string[buffer.Length - 1];
        for (int i = 0; i <= name_buffer.Length - 1; i++)
        {
            name_buffer[i] = buffer[i].Split(':')[1];
        }
    }

    void nextLine()
    {
        if (count <= end)
        {
            if (character_check() && multiple_check())
                content_ui.text = content[count];

            content_ui.GetComponent<TW_Regular>().ORIGINAL_TEXT = content_ui.text;
            content_ui.GetComponent<TW_Regular>().StartTypewriter();
        }
        else
            clear();

        count++;
    }

    bool character_check()
    {
        string[] buffer = content[count].Split(':');

        if (buffer.Length > 1)
        {
            content_ui.text = name_buffer[int.Parse(buffer[0])] + ":" + content[count].Split(':')[1];
            return false;
        }


        return true;
    }

    bool multiple_check()
    {
        string[] buffer = content[count].Split('&');

        if (buffer.Length > 1)
        {
            string[] condition = buffer[1].Split(';');
            multipleStart(condition);
            return false;
        }

        return true;
    }

    void multipleStart(string[] content)
    {
        m_switch++;
        condition.SetActive(true);
        content_ui.text = content[0];
        B1.text = content[1];
        B2.text = content[2]; 
    }

    public void multipleAnswer(int i)
    {
        count++;
        condition.SetActive(false);
        String answer = content[count - 1].Split(';')[i];
        content_ui.text = answer;
        content_ui.GetComponent<TW_Regular>().ORIGINAL_TEXT = answer;
        content_ui.GetComponent<TW_Regular>().StartTypewriter();
        InvokeRepeating("click", 0, 0.1f);
    }

    void clear()
    {
        CancelInvoke("click");
        block.SetActive(false);
        button_block.enabled = false;
        count = 0;
        end = 0;
        content = null;
    }
}