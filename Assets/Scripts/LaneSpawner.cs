using UnityEngine;
using System.Collections;

public class LaneSpawner : MonoBehaviour {


	public GameObject[] lanes;
	public float spawnHorizon = 500f;
	private float offsetNextLane = 0; 
	public float laneWidth = 2; 
	public Transform spawnParent;
	public GameObject player; 

	void Start () {

	
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float positionForward = player.transform.position.z;

		if (positionForward + spawnHorizon > offsetNextLane) {


			int laneIndex = Random.Range (0, lanes.Length);
			GameObject lane = lanes [laneIndex];
			Vector3 nextLanePosition = offsetNextLane * Vector3.forward;
			GameObject newLane = Instantiate (lane, nextLanePosition, Quaternion.identity) as GameObject;
			newLane.transform.parent = spawnParent;
			offsetNextLane += laneWidth;


		}

	}
}
