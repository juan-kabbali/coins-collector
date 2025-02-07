using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//This method is called when you lost or win the game and reloads the scene
	public void reloadGame(){
		SceneManager.LoadScene ("menu");
	}

	public void startGame(){
		SceneManager.LoadScene ("miniJuego_1");
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}


}
