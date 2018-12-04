using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	private TextAsset ep1;
	
	
	// Use this for initialization
	void Start ()
	{
		ep1 = Resources.Load<TextAsset>("ep2");
		Debug.Log(ep1.text.Split('\n')[1]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
