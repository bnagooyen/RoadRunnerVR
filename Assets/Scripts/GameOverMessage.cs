using UnityEngine;
using System.Collections;

public class GameOverMessage : MonoBehaviour {

	private Player player;
	private Canvas canvas;
	private SceneChanger sceneChanger;
	public float UIDistance = 50.0f;

	void Start () {
	
		player = FindObjectOfType<Player> ();
		canvas = GetComponent<Canvas> ();
		sceneChanger = FindObjectOfType<SceneChanger> ();
		canvas.enabled = false;
			
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		if (sceneChanger.isGameOver == true) {
			canvas.enabled = true;
			transform.rotation = Quaternion.LookRotation (player.LookDirection ());
			transform.position = player.transform.position;
			transform.position += player.LookDirection () * UIDistance;
			transform.position += Vector3.up * 50.0f;
		}
	}
}
