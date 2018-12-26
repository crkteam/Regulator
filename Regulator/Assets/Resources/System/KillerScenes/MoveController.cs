using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MoveController : MonoBehaviour
{
    public Slider breatheline;
    public Image blackbackground;
    public Sprite a, b;
    public Shot _shot;
    

    private Canvas canvas;
    private float x, y;
    private float i;

    private int hankshake_count; // 記錄彈跳點
    private float hankshake_x; // 彈跳位置
    private float hankshake_y;
    private int bullet;

    private bool breath_flag;

    private float blow_back_count;

    public Joystick joystick;

    // bullet只能打一次

    private void Awake()
    {
        Application.targetFrameRate = 100; //禎數設定
    }

    // Use this for initialization
    void Start()
    {
        bullet = 1;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();


        InvokeRepeating("normalmove", 0, 0.01f);
        InvokeRepeating("handshake", 0, 0.01f);
    }

    void normalmove()
    {
        if (x < 29 && x > -29 && y < 12 && y > -11)
        {
            // 移動
            transform.Translate(new Vector2(joystick.Horizontal / 5, joystick.Vertical / 5));
            y += joystick.Vertical / 5;
            x += joystick.Horizontal / 5;
        }
        else
        {
            fixcoordinate();
        }
    }

    void fixcoordinate()
    {
        if (x > 29)
        {
            x -= 0.01f;
            transform.Translate(new Vector2(-0.01f, 0));
        }

        if (x < -29)
        {
            x += 0.01f;
            transform.Translate(new Vector2(0.01f, 0));
        }

        if (y > 12)
        {
            y -= 0.01f;
            transform.Translate(new Vector2(0, -0.01f));
        }

        if (y < -11)
        {
            y += 0.01f;
            transform.Translate(new Vector2(0, 0.01f));
        }
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
        y += hankshake_y / 300;
        x += hankshake_x / 300;
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
            GameObject.Find("Fill Area").GetComponent<AudioSource>().enabled = true;
            GameObject.Find("shot_icon").GetComponent<Image>().sprite = b;
            GameObject.Find("Shot").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("aim").GetComponent<AudioSource>().enabled = true;
            CancelInvoke("handshake");
            CancelInvoke("normalmove");
            InvokeRepeating("focusmove", 0, 0.01f);
        }
        else
        {
            GameObject.Find("Fill Area").GetComponent<AudioSource>().enabled = false;
            if(bullet > 0)
                shot();
        }
    }

    void focus_replenish()
    {
        GameObject.Find("Fill Area").GetComponent<AudioSource>().enabled = false;
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
            GameObject.Find("aim").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("Breathe_line").GetComponent<AudioSource>().enabled = false;
            InvokeRepeating("normalmove", 0, 0.01f);
            InvokeRepeating("handshake", 0, 0.01f);
            CancelInvoke("focus_replenish");
        }
    }

    void unfocus()
    {
        CancelInvoke("focusmove");
        GameObject.Find("Breathe_line").GetComponent<AudioSource>().enabled = true;
        blackbackground.enabled = true;
        InvokeRepeating("focus_replenish", 0, 0.01f);
    }

    void shot()
    {
        bullet--;
        GameObject.Find("shot_icon").GetComponent<Image>().sprite = a;
        GameObject.Find("Shot").GetComponent<AudioSource>().enabled = true;
        InvokeRepeating("shake", 0, 0.01f);

        _shot.start();
    }

    void shake()
    {
        blow_back_count += 1.5f;

        if (blow_back_count >= 10)
            CancelInvoke("shake");

        float bx = Random.Range(-0.75f, 0.75f);
        float by = Random.Range(-0.5f, 0.75f);
        x += bx;
        y += by;
        transform.Translate(new Vector2(bx, by));
    }
}