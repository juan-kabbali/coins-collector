using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeftTime : MonoBehaviour {

	public float timeInSeconds;
	public Text countDown;
	private LevelManager lm;
	private bool isTimeStop;

	// Use this for initialization
	void Start () {
		//default, the time is not stop, only when you win to avoid that the game reloads automatically
		isTimeStop = false;
		//get LevelManager reference to use its methods
		lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//change font size and color
		if(timeInSeconds < 5.0f){
			countDown.color = Color.red;
			countDown.fontSize = 30;
		}

		// validate isTimeStop before update the time
		if(!isTimeStop){
			upDateTime ();	
		}

		// reloads the scene if time is up
		if ( timeInSeconds < 0 ){
			lm.reloadGame();
		}
	}

	//Update and set the time into the Text placed into canvas
	private void upDateTime(){
		timeInSeconds -= Time.deltaTime;
		countDown.text = "Tiempo: " + timeInSeconds.ToString();
	}


	//this method return the current value of timeInSeconds
	public float getLeftTime(){
		return this.timeInSeconds;
	}

	//this method set a bool value to isTimeStop
	public void stopTime(bool isStop){
		isTimeStop = isStop;
	}




}
