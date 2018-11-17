using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_Controller : MonoBehaviour
{
    public Image head;

    public Sprite[] icon;

    private char condition;

    private Text content;

    private Dialogur dc;

    private JsonPlayer jp;

    // Use this for initialization
    void Start()
    {
        jp = new JsonPlayer();

        switch (jp.getDialogue())
        {
            case 0:
                condition = '0';
                break;
            case 1:
                condition = '1';
                break;
            case 2:
                condition = '2';
                break;
            case 3:
                condition = '3';
                break;
            case 4:
                condition = '4';
                break;
            case 5:
                condition = '5';
                break;
        }

        dc = new Dialogur("Episode" + condition);
        content = GameObject.Find("content").GetComponent<Text>();

        InvokeRepeating("dialogue", 0, 0.02f);
    }

    void dialogue()
    {
        if (Input.GetMouseButtonDown(0))
        {
            check();
        }
    }

    void check()
    {
        if (dc.check())
        {
            head.sprite = icon[dc.gethead()];
            content.GetComponent<TW_Regular>().ORIGINAL_TEXT = dc.getText();
            runText(content);

            dc.NextLine();
        }
        else
        {
            content.text = "完結";
            head.enabled = false;
        }
    }

    void runText(Text text)
    {
        text.GetComponent<TW_Regular>().StartTypewriter();
    }
}