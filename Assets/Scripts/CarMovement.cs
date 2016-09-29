using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	private float carSpeed;
	private float lifeTime;
	private SceneChanger sceneChanger;

	void Start () {
	
		Invoke ("DestroyObject", lifeTime);
		sceneChanger = FindObjectOfType<SceneChanger> ();
	}

	public void SetCarSpeedAndLife(float speed, float life){

		carSpeed = speed; 
		lifeTime = life;
	}

	void DestroyObject(){

		Destroy (gameObject);

	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.name == "Player") {

			sceneChanger.isGameOver = true;

		}

	}

	// Update is called once per frame
	void Update () {
	
		transform.position += Vector3.right * carSpeed * Time.deltaTime;

	}
}
