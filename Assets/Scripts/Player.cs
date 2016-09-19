using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	CardboardHead cardhead; 
	private Rigidbody rb; 
	public float speed = 10.0f; 
	public float degrees = 60.0f; 
	private float inRadians;
	private bool touchingFloor;

	void Start () {


		inRadians = degrees * Mathf.Deg2Rad;
		Cardboard.SDK.OnTrigger += PullTrigger;
		cardhead = FindObjectOfType<CardboardHead> ();
		rb = GetComponent<Rigidbody> ();
		print (cardhead.Gaze);

	}

	void PullTrigger(){

		if (touchingFloor) {
			
			Vector3 projectedVector = Vector3.ProjectOnPlane (cardhead.Gaze.direction, Vector3.up);
			Vector3 jumpVector = Vector3.RotateTowards (projectedVector, Vector3.up, inRadians, 0);
			rb.velocity = jumpVector * speed;

		}


	}

	void OnCollisionEnter(Collision collision){

		touchingFloor = true;

	}

	void OnCollisionExit(Collision collision){

		touchingFloor = false;

	}
		
	// Update is called once per frame
	void Update () {
	
	
		print (touchingFloor);
	}
}
