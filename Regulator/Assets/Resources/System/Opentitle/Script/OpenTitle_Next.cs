using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 新版scene 都要用SceneManagement做切換

public class OpenTitle_Next : MonoBehaviour
{
    public Image title;

    public Text start;

    private bool flag = true;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && flag)
        {
            flag = false;
            InvokeRepeating("Logoflicker",0,0.1f);
        }
    }

    void Logoflicker()
    {
        Color title = this.title.color;
        Color start = this.start.color;
        title.a -= 0.075f;
        start.a -= 0.075f;

        this.title.color = title;
        this.start.color = start;
        
        if(start.a <= -0.5)
            SceneManager.LoadScene("lobby");
    }
}