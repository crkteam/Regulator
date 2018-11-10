using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_test : MonoBehaviour
{

	public Image head;

	public Sprite[] icon;

	private Text content;

	private DialogueController dc;
	
	// Use this for initialization
	void Start ()
	{
		dc = new DialogueController("Episode1");
		content = GameObject.Find("content").GetComponent<Text>();

		InvokeRepeating("dialogue",0,0.15f);
	}

	void dialogue()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			check();
		}
	}

	void check()
	{
		
		if (dc.check())
		{
			head.sprite = icon[dc.gethead()];
			content.GetComponent<TW_Regular>().ORIGINAL_TEXT = dc.getText();
			runText(content);
			
			dc.NextLine();
		}
		else
		{
			content.text = "完結";
			head.enabled = false;
		}
	}

	void runText(Text text)
	{
		text.GetComponent<TW_Regular>().StartTypewriter();
	}
}
