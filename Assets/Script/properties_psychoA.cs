using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class properties_psychoA : MonoBehaviour {

	public int age = 0;
	public string state = "origin" ;
	public List <GameObject> belonging = new List <GameObject> ();

	void Start () 
	{
		belonging.Add (GameObject.Find("blo_x"));
		belonging.Add (GameObject.Find("blo_skele"));
		belonging.Add (GameObject.Find("moon"));
	}
	

	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "psychoB") 
		{
			state = "mutation1";
			belonging.Remove (GameObject.Find("blo_skele"));
		}
	}
}
