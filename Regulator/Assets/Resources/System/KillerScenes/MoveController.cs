using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;


public class MoveController : MonoBehaviour
{
    public Slider breatheline;
    public Image blackbackground;

    private Canvas canvas;
    private float x, y;
    private float i;

    private int hankshake_count; // 記錄彈跳點
    private float hankshake_x; // 彈跳位置
    private float hankshake_y;

    private bool breath_flag;


    public Joystick joystick;

    // bullet只能打一次

    private void Awake()
    {
        Application.targetFrameRate = 100; //禎數設定
    }

    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        InvokeRepeating("normalmove", 0, 0.01f);
        InvokeRepeating("handshake", 0, 0.01f);
    }

    void normalmove()
    {
        // 移動
        transform.Translate(new Vector2(joystick.Horizontal / 5, joystick.Vertical / 5));
        y += joystick.Vertical / 5;
        x += joystick.Horizontal / 5;
    }


    void handshake()
    {
        hankshake_count++;

        if (hankshake_count > 1000) // 每500換
            hankshake_count = 0;

        if (hankshake_count % 100 == 0)
        {
            hankshake_x = Random.Range(-2f, 2f);
            hankshake_y = Random.Range(-2f, 2f);
        }

        transform.Translate(new Vector2(hankshake_x / 300, hankshake_y / 300));
        y += hankshake_x / 300;
        x += hankshake_y / 300;
    }

    void focusmove()
    {
        if (breatheline.value <= 0)
            unfocus();

        breatheline.value -= 0.001f;
        transform.Translate(new Vector2(joystick.Horizontal / 50, joystick.Vertical / 50));
        y += joystick.Vertical / 50;
        x += joystick.Horizontal / 50;
    }

    public void focus()
    {
        if (breatheline.value >= 1)
        {
            CancelInvoke("handshake");
            CancelInvoke("normalmove");
            InvokeRepeating("focusmove", 0, 0.01f);
        }
        else
        {
            
        }
    }

    void focus_replenish()
    {
        Color color = blackbackground.color;
        color.a -= 0.002f;
        blackbackground.color = color;
        
        if (breatheline.value < 1)
        {
            breatheline.value += 0.002f;
            
        }
        else
        {
            color.a = 1;
            blackbackground.color = color;
            blackbackground.enabled = false;
            InvokeRepeating("normalmove", 0, 0.01f);
            InvokeRepeating("handshake", 0, 0.01f);
            CancelInvoke("focus_replenish");
        }
    }

    void unfocus()
    {
        CancelInvoke("focusmove");
        blackbackground.enabled = true;
        InvokeRepeating("focus_replenish", 0, 0.01f);
    }

    void shot()
    {
        
    }
}