using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class btree_nodes1_pychoA : MonoBehaviour 
{
	List <nodes> l_nodes1_PsyA = new List<nodes> ();

	public static int num_state = 0; // jiushi currentState

	public int whichPass = 0;

	public static float t1 = 0f;

	bool is_col_psy_cho_b = false;

	public Sprite sp_p_c;

	public int max;


	nodes b_A = new nodes();
	nodes b_B = new nodes();
	nodes b_C = new nodes();
	nodes b_D = new nodes();



	void Start()
	{
		l_nodes1_PsyA.Add (b_A);
		l_nodes1_PsyA.Add (b_B);
		l_nodes1_PsyA.Add (b_C);
		l_nodes1_PsyA.Add (b_D);
	}
		
	bool Pass2Float 
	{// 改成method
		//get { return transform.position.x == 0;}
		get { return t1 > 2f;}
	}

	bool Pass5Float 
	{// 改成method
		//get { return transform.position.x == 0;}
		get { return t1 >5f;}
	}
	bool Pass9Float 
	{// 改成method
		//get { return transform.position.x == 0;}
		get { return t1 >9f;}
	}
	bool Pass90Float 
	{// 改成method
		//get { return transform.position.x == 0;}
		get { return t1 >90f;}
	}
	bool isColWithPyscoB
	{
		get { return is_col_psy_cho_b;}
	}
		
	void Get1Conditions (bool condition)
	{
		whichPass = 0;
		if (condition) 
		{whichPass = 1;}
		if (!condition) 
		{whichPass = 2;}
	}
	void Get2Conditions (bool conditionA, bool conditionB)
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

//		for (int i = 0; i < l_nodes1_PsyA.Count; i++) 
//		{
//			if (num_list  == i) 
//			{
			//	l_nodes1_PsyA [i].PassTo (ConditionA, ConditionB); //判断CHECKNEXTPREVIOUS（）的条件
			//	l_nodes1_PsyA [i].CheckNextPrevious
			//	(GetComponent<nodes>().PassTo(GetComponent<nodes>().ConditionA,GetComponent<nodes>().ConditionB));//如果是就继续走，否就返回，"0"就什么都不做

			//State
			//GetConditions(ConditionA, false);// if it is an excuteable node, there will be no GetConditions and CheckNextPrevious
			//l_nodes1_PsyA[i].CheckNextPrevious(whichPass);//go previous or go next 
			//l_nodes1_PsyA [i].Do1 (); // do something

			//state0
		//

		if (num_state == 0) 
		{
			Get1Conditions (Pass2Float);

			b_A.CheckNextPrevious (whichPass);// if all true, pass. If one is false, go back.
			//b_A.CheckNext (whichPass);//if false, pass
		}

		if (num_state == 1) 
		{
			Get1Conditions (true);
			b_A.Do_GoToPlaceA (gameObject, GameObject.Find ("placeA"));

			b_A.CheckNextPrevious (whichPass);
		}

		if (num_state == 2) 
		{
			Get2Conditions (Pass5Float, true);

			b_A.CheckNextPrevious (whichPass);
		}

		if (num_state == 3) 
		{
			Get1Conditions (true);

			b_A.Do_GoToPlaceA (gameObject, GameObject.Find ("placeB"));
			b_A.CheckNextPrevious (whichPass);
		}

		if (num_state == 4) 
		{
			Get2Conditions (Pass9Float, true);

			b_A.CheckNextPrevious (whichPass);
		}

		if (num_state == 5) 
		{
			Get1Conditions (isColWithPyscoB);

			b_A.CheckNextPrevious (whichPass);
		}

		if (num_state == 6) 
		{
			Get1Conditions (true);

			b_A.ChangeAppearance(gameObject,"psychoC");
			b_A.CheckNextPrevious (whichPass);
		}

		if (num_state == 7) 
		{
			Get1Conditions (Pass90Float);

			b_A.CheckNext (whichPass);//if false, pass
		}

		if (num_state == 8) 
		{
			Get1Conditions (true);

			b_A.Do_GoToPlaceA (gameObject, GameObject.Find ("placeC"));
			b_A.CheckNextPrevious (whichPass);
		}


		if (num_state == max ) 
		{
			num_state = 0;
			print ("back to zero.");
		}
		if (num_state < 0) 
		{
			num_state = 0;
		}
	//	print (num_list);
		//Debug.Log ("num_list: " + num_list);
//		if (!GetComponent<nodes> ())
//			print ("HAS SOMETHING.");
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "psychoB") 
		{
			is_col_psy_cho_b = true;
			print ("collide with C");
		}

		if (other.gameObject.name == "placeC") 
		{
			GetComponent<SpriteRenderer> ().sprite = sp_p_c;
			print ("collide with placeC");
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "psychoB") 
		{
			is_col_psy_cho_b = false;
			print ("exit collide with B");
		}
	}
}

public class nodes: MonoBehaviour
{
	public string aaa;

	public bool isPunch = false;


	public virtual void CheckNextPrevious(int ispass) // only rhombus node do this
	{		
		if (ispass == 1) // to next
		{
			btree_nodes1_pychoA.num_state = btree_nodes1_pychoA.num_state + 1;
			//Debug.Log ("+1");

		}
		if (ispass  == 2) // to previous
		{
			btree_nodes1_pychoA.num_state = btree_nodes1_pychoA.num_state - 1;
			//Debug.Log ("-1");
		}
	}

	public virtual void CheckNext(int ispass2)
	{
		if (ispass2 == 2) 
		{
			btree_nodes1_pychoA.num_state = btree_nodes1_pychoA.num_state + 1;
		}
	}

	public virtual void Do1() // only square node do this
	{	
		Debug.Log (aaa);
	}
		
	public virtual void Do_GoToPlaceA(GameObject goj, GameObject goj2) // only square node do this
	{	
		//Debug.Log ("go to Place A");

		goj.GetComponent<Rigidbody2D> ().DOMove (goj2.transform.position, 1f);
	}

	public virtual void GetCurrentTime()
	{
		btree_nodes1_pychoA.t1 = Time.time;
	}
		
	public virtual void ChangeAppearance(GameObject goj, string spriteName)
	{
		goj.GetComponent<SpriteRenderer> ().sprite = Resources.Load (spriteName, typeof(Sprite)) as Sprite;

		if (!isPunch)
		{
		goj.transform.DOPunchScale (new Vector3 (2f, 2f, 1f), 0.3f, 10, 1);
		isPunch = true;
	    }

	}
}

  
