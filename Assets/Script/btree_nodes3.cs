﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class btree_nodes3 : MonoBehaviour 
{
	List <nodes2> l_nodes2_PsyB = new List<nodes2> ();

	public static int num_list2 = 0; // jiushi currentState

	public int whichPass = 0;

	float t1 = 0f;
	float t2 = 0f;

	void Start()
	{
		nodes2 b_A = new nodes2("a");
		nodes2 b_B = new nodes2("b");
		nodes2 b_C = new nodes2("c");
		nodes2 b_D = new nodes2("d");

		l_nodes2_PsyB.Add (b_A);
		l_nodes2_PsyB.Add (b_B);
		l_nodes2_PsyB.Add (b_C);
		l_nodes2_PsyB.Add (b_D);
	}

	 bool Pass4Float 
	{// 改成method
		//get { return transform.position.x == 0;}
		get { return t1 >4f;}
	}
		

	 bool Pass9Float
	{// 改成method
		//get { return transform.position.x == 0;}
		get { return t1 >9f;}
	}
    void GetConditions (bool conditionA, bool conditionB)
	{
		whichPass=  0;
		if (conditionA && conditionB)
			whichPass = 1;
		if (!conditionA || !conditionB)
			whichPass = 2;
	}

	void Update()// do TO the previous and TO the next
	{
		t1 = Time.time;

		//state0
		if (num_list2 == 0) 
		{
			GetConditions (Pass4Float, true);
			l_nodes2_PsyB [num_list2].Do_GoToPlaceA (gameObject, GameObject.Find ("placeB"));
			l_nodes2_PsyB [num_list2].CheckNextPrevious (whichPass);
		}

		if (num_list2 == 1) 
		{
			GetConditions (Pass9Float, true);
			l_nodes2_PsyB [num_list2].CheckNextPrevious (whichPass);

		}

		if (num_list2 == 2) 
		{
			GetConditions (true, true);
			l_nodes2_PsyB [num_list2].CheckNextPrevious (whichPass);
			l_nodes2_PsyB [num_list2].Do_GoToPlaceA (gameObject, GameObject.Find ("placeA"));


		}



		if (num_list2 == l_nodes2_PsyB.Count ) 
		{
			num_list2 = 0;
			print ("back to zero.");
		}
		if (num_list2 < 1) 
		{
			num_list2 = 0;
		}

		//Debug.Log ("num_list: " + num_list);
		//		if (!GetComponent<nodes> ())
		//			print ("HAS SOMETHING.");
	}
}

public class nodes2: MonoBehaviour
{
	public string aaa;
	//	public int isPass;

	public nodes2(string st)
	{aaa = st;}

	public virtual void Do1() // only square node do this
	{	
		Debug.Log (aaa);
	}

	public virtual void Do_GoToPlaceA(GameObject goj, GameObject goj2) // only square node do this
	{	
		//Debug.Log ("go to Place A");

		goj.GetComponent<Rigidbody2D> ().DOMove (goj2.transform.position, 3f);
	}

	public virtual void CheckNextPrevious(int ispass) // only rhombus node do this
	{		
		if (ispass == 1) // to next
		{
			btree_nodes3.num_list2 = btree_nodes3.num_list2 + 1;
			//Debug.Log ("+1");

		}
		if (ispass  == 2) // to previous
		{
			btree_nodes3.num_list2 =btree_nodes3.num_list2 - 1;
			//Debug.Log ("-1");
		}
	}
}

