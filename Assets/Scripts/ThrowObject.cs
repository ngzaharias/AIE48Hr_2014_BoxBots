using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowObject : MonoBehaviour 
{
	public enum ThrowType
	{
		one,
		two,
		three,
		four
	};

	public int IsStuck = 0;
	public ThrowType MyType;

	List<Rigidbody> ContectedStuff;

	private float spawnTime;
	private float lifeTime = 3.0f;

	// Use this for initialization
	void Start () 
	{
		ContectedStuff = new List<Rigidbody>();
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (spawnTime + lifeTime <= Time.time && ContectedStuff.Count == 0) {
			Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter(Collision collision) 
	{
		if(collision.contacts[0].otherCollider.transform.rigidbody != null)
		{
			ThrowObject  temp = collision.contacts[0].otherCollider.GetComponent<ThrowObject>() ;
			if(temp != null && 
			   temp.MyType != MyType && 
			   temp.transform.parent != transform)
			{
				if(!ContectedStuff.Contains(collision.contacts[0].otherCollider.transform.rigidbody))
				{
					gameObject.AddComponent<FixedJoint>().connectedBody = collision.contacts[0].otherCollider.transform.rigidbody ;
					ContectedStuff.Add(collision.contacts[0].otherCollider.transform.rigidbody );
				}
			}
		}

		////	If objects should be removed straight away
		//if (ContectedStuff.Count == 0) {
		//	Destroy(this.gameObject);
		//}
		
	}
}




















