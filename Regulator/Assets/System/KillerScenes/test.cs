using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Canvas c;
    private float x, y;
    private float i;
    public Joystick joystick;

    private float speed;

    private float init;
    // bullet只能打一次
    
    // Use this for initialization
    void Start()
    {
        speed = 0.1f;
        init = 0.1f;
        c = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {    
        // 移動
        transform.Translate(new Vector2(joystick.Horizontal/2,joystick.Vertical/2));
        y += joystick.Vertical/2;
        x += joystick.Horizontal/2;
        
    }

    // 需更改
    void check(float x, float y)
    {
        // 座標最好要用更好的方法
        if (x < -16.2 && x > -17.3)
        {
            if (y > 7.6 && y < 9.7)
            {
                Debug.Log("敵人1");
                GameObject.Find("enemy1").active = false;
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

    public void shot()
    {

            Vector2 v = c.transform.position; // 去抓大圖的x,y軸
            v.x += x; // 因為兩者座標不同 只能用插值來運算
            v.y += y;
                
            Debug.Log("x:"+x+"y:"+y);
            check(v.x, v.y); // 要改成 專用的判斷者 一張圖一個
     }
}