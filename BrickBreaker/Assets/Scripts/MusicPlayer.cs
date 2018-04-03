
using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer musicPlayer = null;
	
	void Awake () {	
		if(musicPlayer != null){
			Destroy (gameObject);
		}
		else{
			musicPlayer = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Start () {

	}
	
	
	void Update () {
	
	}
	
}
