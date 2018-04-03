using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private Ball ball;
	private float mousePosInBlocks;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();	
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse ();
		}else{
			AutoPlay();	
		}
	}
	
	void MoveWithMouse () {
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;	
		Vector3 paddlePos =  new Vector3(8.0f, this.transform.position.y, 0f);
		paddlePos.x = Mathf.Clamp (mousePosInBlocks,0.5f,15.5f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay(){
		Vector3 paddlePos =  new Vector3(8.0f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x,0.5f,15.5f);
		this.transform.position = paddlePos;
	}
}
