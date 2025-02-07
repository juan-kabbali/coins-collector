using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour {

	public int rotationSpeed;

	void Start () {

	}
	
	void Update () {
		//rotate the coins
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);

	}
}
