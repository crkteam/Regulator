using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
	private Image image;

	// Use this for initialization
	void Start ()
	{
		image = GameObject.Find("Scenes").GetComponent<Image>();
		InvokeRepeating("openScenes",0,0.1f);
	}

	void openScenes()
	{
		//開始漸淡
		//if(漸淡完){
		//		GameObject.Find("Main Camera").GetComponent<LobbyController>().enabled = true;
		//}
	}
}
