using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class OpenTitle_Title : MonoBehaviour
{
    private float time;
    public Image image , title , GameLoge,background;
    public Text start;
    private Color buffer_color;
    private int count = 0; // 0 顯入 1 淡出 2 刪除

    // Use this for initialization
    void Start()
    {
        buffer_color = image.color;
        InvokeRepeating("testt",0,0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void testt()
    {
        if (count == 2)
            init();
        else
            control(count); 
    }

    void init() // 打開開始畫面
    {
        count = 3;
        title.enabled = true;
        GameLoge.enabled = true;
        title.GetComponent<OpenTitle_Next>().enabled = true;
        start.GetComponent<TW_Regular>().StartTypewriter();
    }

    void control(int count) 
    {
        if (count == 0)
        {
            buffer_color.a += 0.0075f;
            if (buffer_color.a > 1.5)
                this.count = 1;
        }
        else if (count == 1)
        {
            Color back = background.color;
           
            buffer_color.a -= 0.0075f;
            if (buffer_color.a <= 0 && Time.time > 5.5)
            {
                //背景漸漸變白
                back.r += 0.003f;
                back.g += 0.003f;
                back.b += 0.003f;
                background.color = back;
                if (back.r >= 1f) //全白跳出LOGO
                {
                    this.count = 2;
                    Destroy(image.gameObject);
                    
                }
              
            }
        }

        image.color = buffer_color;
    }

}