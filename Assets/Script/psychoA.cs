using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Node 
{
	public bool isCheck;
	public bool isPass;


	public void CheckExter()
	{

	}

	public void CheckIsPass()
	{
		if (isPass)
		{
			//do next
		}
		if (!isPass) 
		{//do previous
		}
	}

	//
	void Do()
	{
		Debug.Log ("do.");
	}
}





public class psychoA : MonoBehaviour {

	//List <DoNode, checkNode> l_btree = new List<DoNode, checkNode> ();

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//do the current node's stuff. then to see what would happen.

	}
}
