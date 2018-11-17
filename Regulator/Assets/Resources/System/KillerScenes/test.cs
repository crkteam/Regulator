using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private Canvas ccc;
    private float x, y;
    private float i;
    public Joystick joystick;
    public GameObject g;

    private PolygonCollider2D p;
    // bullet只能打一次

    private void Awake()
    {
        Application.targetFrameRate = 100; //禎數設定
    }

    // Use this for initialization
    void Start()
    {
        ccc = GameObject.Find("Canvas").GetComponent<Canvas>();
        p = GameObject.Find("d").GetComponent<PolygonCollider2D>();
        InvokeRepeating("move", 0, 0.01f);
    }

    void move()
    {
        // 移動
        transform.Translate(new Vector2(joystick.Horizontal / 2, joystick.Vertical / 2));
        y += joystick.Vertical / 2;
        x += joystick.Horizontal / 2;
        if (Input.GetKey(KeyCode.Space))
            shot();
    }

    // 需更改
    void check(float a, float b)
    {
        Debug.Log(p.OverlapPoint(new Vector2(a, b)));
//        if (p.bounds.Contains(new Vector3(a, b, 42.7f)))
//        {
//            Instantiate(g, new Vector3(a, b, 42.7f), transform.rotation, ccc.transform);
//        }
    }

    public void shot()
    {
        Vector2 v = ccc.transform.position; // 去抓大圖的x,y軸
        v.x += x; // 因為兩者座標不同 只能用插值來運算
        v.y += y;

        Debug.Log("x:" + x + "y:" + y);
        check(v.x, v.y); // 要改成 專用的判斷者 一張圖一個
    }
}