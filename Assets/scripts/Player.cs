using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Player : MonoBehaviour {

	public float force;
	public GameObject myCamera;
	public Text txtScore;
	private LeftTime leftTime;
	public Button btnRestart;
	public ParticleSystem particulas;

	private Rigidbody rb;
	private Vector3 offsetCamera;
	private int score;
	private GameObject[] coinsArray;
	private int numberOfCoins;


	void Start () {
		rb = GetComponent<Rigidbody>();
		leftTime = GameObject.Find("timeLeft").GetComponent<LeftTime>();
		offsetCamera = myCamera.transform.position;
		score = 0;
		coinsArray = GameObject.FindGameObjectsWithTag("coin");
		numberOfCoins = coinsArray.Length;
		Debug.Log("numero de coins" + numberOfCoins);
		btnRestart.gameObject.SetActive(false);
	}
	
	void Update () {
		movePlayerAndCamera ();

	}

	//this method is executed when a rigidBody collids with BoxCollider
	void OnTriggerEnter(Collider obj){
		//Destroy(obj.gameObject);
		if(obj.gameObject.tag == "coin"){
			//this method does not destroy the object, only is not rendered.
			obj.gameObject.SetActive(false);
			score++;
			particulas.maxParticles++;
			txtScore.text = "Puntaje: " + score.ToString();
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
			validateVictory();
		}

	}

	//validate game over to stop the time
	private void validateVictory(){
		if(score == numberOfCoins && leftTime.getLeftTime() > 0.0f ){
			leftTime.stopTime (true);
			txtScore.text="Ganaste";
			btnRestart.gameObject.SetActive(true);
		}
	}

	// this method move the player using inputs, create simple chase camera effect and set particles initial position
	private void movePlayerAndCamera(){
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		//Debug.Log("Input Axis Horizantal --> " + horizontal + " // Input Axis Vertical --> " + vertical);
		Vector3 vector = new Vector3(horizontal, 0.5f, vertical);
		//Use delta time to make fluid the transition
		rb.AddForce(vector * force * Time.deltaTime);
		myCamera.transform.position = this.transform.position + offsetCamera;
		particulas.transform.position = rb.position;

	}

	

}


























