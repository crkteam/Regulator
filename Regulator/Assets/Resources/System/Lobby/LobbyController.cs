using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    private Dialogur dc;
    public Text content;
    public Image head;
    public Sprite[] icon;
    public GameObject dialogue_space,nextStage;

    private JsonPlayer jp; // 統一在這裡管理 接收json

    // Use this for initialization
    void Start()
    {
        jp = new JsonPlayer();
        lobby();
    }

    void lobby()
    {
        char condition = ' ';
        jp = new JsonPlayer();
        switch (jp.getDialogue())
        {
            case 0:
                condition = '0';
                break;
            case 1:
                condition = '1';
                break;
        }

        lobby_start();
        dc = new Dialogur("Episode" + condition);
    }

    void lobby_start()
    {
        dialogue_space.SetActive(true);
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
        else  //全部結束後出現
        {
            dialogue_space.SetActive(false);
            CancelInvoke("dialogue");
            nextStage.SetActive(true);
        }
    }

    void runText(Text text)
    {
        text.GetComponent<TW_Regular>().StartTypewriter();
    }
}
