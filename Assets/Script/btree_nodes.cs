//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//class PAEvent
//{
//	public string eventname;
//	public bool node;
//
//	public PAEvent(string eventName, bool Node)
//	{
//		eventname = eventName;
//		node = Node;
//	}
//}
//
//
//class checkNode
//{
//	public bool isPass;
//
//	public void CheckExt()
//	{
//		
//	}
//
//	public void CheckIsPass()
//	{
//		if (isPass)
//		{
//			//do next
//		}
//		if (!isPass) 
//		{//do previous
//		}
//	}
//}
//
//class DoNode
//{
//	void Do()
//	{
//		Debug.Log ("do.");
//	}
//}
//
//class IsInPlaceA: checkNode
//{
//	
//}
//
//public class btree_nodes : MonoBehaviour {
//
////	public List <bool> l_btreeP_A = new List<bool> ();
//    List <PAEvent> l_btreeP_A;
//
////	enum StatePyschoA
////	{ 
////		toPlaceA,
////		toPlaceB,
////		toPlaceC
////	}
//
//
//
//	void Start ()
//	{
//
//		List <PAEvent> l_btreeP_A = new List<PAEvent> ();
//		int num_btreeP_A =  0;// current state in the list
//
//		PAEvent a = new PAEvent ("gotoA", true);
//
//		PAEvent b = new PAEvent ("gotoB", false);
//
//		PAEvent c = new PAEvent ("gotoC", false);
//
//
//		l_btreeP_A.Add (a);
////		l_btreeP_A.Add (b);
//
////		for (int i = 0; i < l_btreeP_A.Count; i++) 
////		{
////			Debug.Log (i+" : " +l_btreeP_A[i].eventname);
////		}
//
////		List<TestA> ltestA = new List<TestA> ();
////
////		TestA aa = new TestA ();
////
////		ltestA.Add (aa);
////		ltestA.Add (aa);
////		for (int i = 0; i < ltestA.Count; i++) 
////		{
////			ltestA [i].debug ();
////		}
//	}
//	
//	// Update is called once per frame
//	void Update () 
//	{
//
//	}
//
//	void OnCollisionEnter2D(Collision2D col)
//	{
//		Debug.Log (gameObject.name + " collide with me.");
//	}
//
//
////	class TestA
////	{
////		public void debug()
////		{
////			Debug.Log ("aa aa.");
////		}
////	}
//}


