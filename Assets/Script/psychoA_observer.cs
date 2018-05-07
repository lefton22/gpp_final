using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class psychoA_observer : MonoBehaviour {
	
	ShapeState shapeState1 = new ShapeState ();

	public Sprite sprite1;
	public Sprite sprite2;

	void Start ()
	{
		WatchShape ob1 = new WatchShape (shapeState1);
		shapeState1.RegisterObserver (ob1);
		shapeState1.ShapeStatState = "mutation0";
	}


	void Update () 
	{
		//shapeState1.ShapeStatState = "wendu 90";
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "psychoB") 
		{
			shapeState1.ShapeStatState = "mutation1";
			shapeState1.ShapeSrite = sprite1;
			GameObject.Find("ui_psychoA").GetComponent<SpriteRenderer> ().sprite = sprite1;
			//belonging.Remove (GameObject.Find("blo_skele"));
		}

		if (other.gameObject.name == "placeC") 
		{
			shapeState1.ShapeStatState = "mutation2";
			shapeState1.ShapeSrite = sprite2;
			GameObject.Find("ui_psychoA").GetComponent<SpriteRenderer> ().sprite = sprite2;
			//belonging.Remove (GameObject.Find("blo_skele"));
		}
	}

	public abstract class Subject
	{
		List<Observer> mObservers = new List<Observer>();

		public void RegisterObserver(Observer ob)
		{
			mObservers.Add (ob);
		}
		public void RemoveObserver(Observer ob)
		{
			mObservers.Remove (ob);
		}
		public void NotifyObserver()
		{
			foreach (Observer ob in mObservers) 
			{
				ob.Update ();
			}
		}
	}

	public class ShapeState: Subject
	{
		private string mShapeState;
		public string ShapeStatState
		{
			set{ mShapeState = value; 
				NotifyObserver ();
			   }
			get { return mShapeState;}
		}

		private Sprite mSprite;
		public Sprite ShapeSrite
		{
			set{ mSprite = value;
				NotifyObserver ();}
			get { return mSprite; }
		}
	}

	public abstract class Observer
	{
		public abstract void Update();
	}

	public class WatchShape: Observer
	{
		public ShapeState mSub;
		public WatchShape (ShapeState sub)
		{
			mSub = sub;
		}


		public override void Update()
		{
			Debug.Log ("Observer display: " + mSub.ShapeStatState);
		}
	}

//	public class WatchShapeUI:Observer
//	{
//		public 
//	}


}
