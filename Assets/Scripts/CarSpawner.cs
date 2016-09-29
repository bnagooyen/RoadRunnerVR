using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour {

	public GameObject[] cars;
	Vector3 carStartPosition;
	public float carSpeed;
	public float life;
	bool generateCars = true;


	void Start () {
		InstantiateCar ();
		StartCoroutine(ContinuousGenerateCars());

	}

	void InstantiateCar(){

		GameObject newCar = Instantiate (cars [0]);
		newCar.transform.position = GetPosition();
		newCar.transform.parent = transform;

		carSpeed = Random.Range (3, 10);
		life = 20.0f;
		CarMovement carComponent = newCar.GetComponent<CarMovement> ();
		carComponent.SetCarSpeedAndLife (carSpeed, life);


	}

	Vector3 GetPosition(){

		carStartPosition = transform.position;
		carStartPosition += Vector3.up * 1.0f;
		carStartPosition += Vector3.left * 50.0f;

		return carStartPosition;


	}

	IEnumerator ContinuousGenerateCars(){

		while (generateCars == true) {

			InstantiateCar ();

			yield return new WaitForSeconds(5);

		}



	}
	// Update is called once per frame
	void Update () {
	
	}
}
