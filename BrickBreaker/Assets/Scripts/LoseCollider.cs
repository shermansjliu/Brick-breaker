using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager levelManager;
	

		
	
	void OnTriggerEnter2D (Collider2D trigger){ //Collider2D = the type of object that is going to be passed in
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Lose");
	}
	
	

	
}
