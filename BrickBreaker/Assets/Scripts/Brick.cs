using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	
	public Sprite[] hitSprites;
	public static int breakableCount;
	public AudioClip crack;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable; 

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		
		//Keep track of breakable breaks
		if(isBreakable){
			breakableCount++;
		}

		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		}
	void OnCollisionExit2D (Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.5f);
		if(isBreakable){
			HandleHits();
		}
		
	
	}
	
	void HandleHits(){
		int maxHits = hitSprites.Length+1;
		timesHit++;
		if(timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy (gameObject);
		}
		else{
			LoadSprites();
		}
	}
	
	void LoadSprites (){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}	
	}
	
	
	//TODO remove this method once we can actually win
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	
}
