using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Canvas c;
    private float x, y;
    private float i, bullet;
    // bullet只能打一次
    
    // Use this for initialization
    void Start()
    {
        c = GameObject.Find("Canvas").GetComponent<Canvas>();
        bullet++; 
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 v = c.transform.position; // 去抓大圖的x,y軸
                v.x += x; // 因為兩者座標不同 只能用插值來運算
                v.y += y;

                check(v.x, v.y); // 要改成 專用的判斷者 一張圖一個
                bullet--;
            }
        }

        // 移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y += (float) 0.1;
            transform.Translate(new Vector3(0, (float) 0.1, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            y -= (float) 0.1;
            transform.Translate(new Vector3(0, (float) -0.1, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x -= (float) 0.1;
            transform.Translate(new Vector3((float) -0.1, 0, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            x += (float) 0.1;
            transform.Translate(new Vector3((float) 0.1, 0, 0));
        }
    }

    // 需更改
    void check(float x, float y)
    {
        // 座標最好要用更好的方法
        if (x < 13 && x > 12)
        {
            if (y > -12 && y < -10)
            {
                Debug.Log("眼睛");
            }
        }

        if (x < 15 && x > 13)
        {
            if (y < -16 && y > -18)
            {
                Debug.Log("嘴巴");
            }
        }
    }
}