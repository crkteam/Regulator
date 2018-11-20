using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 新版scene 都要用SceneManagement做切換

public class OpenTitle_Next : MonoBehaviour
{
    public Image title,background;

    public Text start;

    private bool flag =false;


    // Use this for initialization
    void Start()
    {
        //重置顏色
        Color back = this.background.color;
        back.r = 1f;
        back.g = 1f;
        back.b = 1f;
        background.color = back;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!flag)
        {
            
            Invoke("Logofade_in",0.0f);
          
        }
        else if(Input.GetMouseButtonDown(0)&&flag)
        {
            
            InvokeRepeating("Logoflicker",0.0f,0.1f);
        }
    }

    void Logofade_in()
    {
        //字幕淡入
        Color title = this.title.color;
        title.a += 0.005f;

        this.title.color = title;
        if (title.a >= 1 )
        {
            flag = true;
        }
    }
    void Logoflicker()
    {
        Color title = this.title.color;
        Color start = this.start.color;
        Color back = background.color;
        title.a -= 0.075f;
        start.a -= 0.075f;
        // 顏色漸減
        back.r -= 0.03f;
        back.g -= 0.03f;
        back.b -= 0.03f;
        background.color = back;
        this.title.color = title;
        this.start.color = start;
     //全黑後開啟下一張scene
        if(background.color.r<=0)
            SceneManager.LoadScene("lobby");
    }
}