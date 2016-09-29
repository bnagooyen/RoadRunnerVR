using UnityEngine;
using System.Collections;

public class FlameFollower : MonoBehaviour {

	public float fireSpeed = 3;  
	private Player player;
	private SceneChanger sceneChanger;


	void Start () {
	
		player = FindObjectOfType<Player> ();
		sceneChanger = FindObjectOfType<SceneChanger> ();
		sceneChanger.isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
	

		Vector3 delta = player.transform.position - transform.position;
		Vector3 projectedDelta = Vector3.Project (delta, Vector3.left);
		transform.position += projectedDelta;

		transform.position += Vector3.forward * fireSpeed;

		CheckPlayerGameOver ();
	}


	void CheckPlayerGameOver(){

		if (player.transform.position.z < transform.position.z) {

			sceneChanger.isGameOver = true;

		}


	}

}
