using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	CardboardHead cardhead; 
	private Rigidbody rb; 
	public float speed = 10.0f; 
	public float degrees = 60.0f; 
	private float inRadians;
	private bool touchingFloor;
	private float lastJumpRequestTime = 0.0f; 

	void Start () {


		inRadians = degrees * Mathf.Deg2Rad;
		Cardboard.SDK.OnTrigger += PullTrigger;
		cardhead = FindObjectOfType<CardboardHead> ();
		rb = GetComponent<Rigidbody> ();
		print (cardhead.Gaze);

	}

	void PullTrigger(){

		RequestJump ();

	}


	private void Jump(){


		Vector3 projectedVector = Vector3.ProjectOnPlane (cardhead.Gaze.direction, Vector3.up);
		Vector3 jumpVector = Vector3.RotateTowards (projectedVector, Vector3.up, inRadians, 0);
		rb.velocity = jumpVector * speed;

	}

	private void RequestJump(){

		lastJumpRequestTime = Time.time;
		rb.WakeUp ();
	}

	void OnCollisionStay(Collision collision){

		float delta = Time.time - lastJumpRequestTime;

		if (delta < 0.1f) {

			Jump ();
			lastJumpRequestTime = 0.0f;

		}

	
	}
		
	// Update is called once per frame
	void Update () {
	
	

	}
}
