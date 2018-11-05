using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	private string Scene;

	private JsonPlayer jp; // 統一在這裡管理 接收json
	// Use this for initialization
	void Start ()
	{
		Scene = SceneManager.GetActiveScene().name;
		jp = new JsonPlayer();
		
		if (Scene.Equals("OpenTitle"))
		{
			if (jp.getLobby() == 0)
			{
				GameObject.Find("Start").GetComponent<Text>().text = "開始新遊戲";
			}else
				GameObject.Find("Start").GetComponent<Text>().text = "繼續遊戲";
		}
		
		if (Scene.Equals("Lobby"))
		{
				GameObject.Find("Text").GetComponent<Text>().text = "開啟任務"+jp.getLobby().ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
