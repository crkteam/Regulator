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

    public int group;
    private int count;
    // objcet
    private ItemController itemDialogue;


    void Start()
    {
        group = 0;
        itemDialogue = GameObject.Find("ItemDialogue").GetComponent<ItemController>();
    }

    public void startDialogue()
    {
        itemDialogue.startDialogue(item,group);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}