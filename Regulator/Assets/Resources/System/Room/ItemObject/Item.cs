using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // String
    public TextAsset item;
    public String[] content;

    private int count;
    // objcet
    private GameObject itemDialogue;

    // Use this for initialization
    void Start()
    {
        Debug.Log("apple");
        content = item.text.Split('\n');
        itemDialogue = GameObject.Find("ItemDialogue");
        
        openBlock();
    }

    void openBlock()
    {
        itemDialogue.SetActive(true);
    }
    
    void startDialogue()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}