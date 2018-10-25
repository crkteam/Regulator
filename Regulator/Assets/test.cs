using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
	public Camera camera;
	public GameObject kill;
	public Canvas c;
	private float x, y;

	// Use this for initialization
	void Start ()
	{
		c = GameObject.Find("Canvas").GetComponent<Canvas>();
		camera = GetComponent<Camera> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow))
		{
			y+=(float)0.1;
			transform.Translate(new Vector3(0,(float)0.1,0));
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			y-=(float)0.1;
			transform.Translate(new Vector3(0,(float)-0.1,0));
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			x-=(float)0.1;
			transform.Translate(new Vector3((float)-0.1,0,0));
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			x+=(float)0.1;
			transform.Translate(new Vector3((float)0.1,0,0));
		}

		if (Input.GetKey(KeyCode.Space))
		{
			GameObject a = Instantiate(kill);
			Vector3 v = c.transform.position;
			v.x += x;
			v.y += y;
			
			a.transform.position = v;
			a.transform.SetParent(c.transform);
			Debug.Log(x+","+y);
		}
	}
}
