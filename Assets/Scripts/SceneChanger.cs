using UnityEngine;
using System.Collections;


public class SceneChanger : MonoBehaviour {

	public bool isGameOver { get; set; }

	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetLevel(){

		Application.LoadLevel ("Main");

	}

	public void MainMenu(){

		Application.LoadLevel ("START");

	}


}
