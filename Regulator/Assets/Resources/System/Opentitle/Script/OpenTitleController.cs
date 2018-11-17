using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenTitleController : MonoBehaviour
{
    private string Scene;
    private Dialogur dc;

    private JsonPlayer jp; // 統一在這裡管理 接收json

    // Use this for initialization
    void Start()
    {
        jp = new JsonPlayer();
        if (jp.getLobby() == 0)
        {
            GameObject.Find("Start").GetComponent<Text>().text = "開始新遊戲";
        }
        else
            GameObject.Find("Start").GetComponent<Text>().text = "繼續遊戲";
    }
}