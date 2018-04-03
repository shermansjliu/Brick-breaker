using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;//Calculate distance between brick and Ball
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			//Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
		

		
		//Wait for mouse left click to launch
		if(Input.GetMouseButtonDown(0)){
			hasStarted = true;
			//To Launch Ball give it a velocity
			this.rigidbody2D.velocity = new Vector2 (2f,10f);
			print ("Mouse Button is clicked, Launch Ball");
				
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if(hasStarted){
			audio.volume = 0.5f;
			audio.Play ();
			}
		//Creating the random velocity
		
		
		//Adding the velocity
		rigidbody2D.velocity += tweak;
		
	}
}