using UnityEngine;
using System.Collections;


public class Brick : MonoBehaviour {

	public AudioClip crackSound;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	
	private int timesHit;
	private LevelManager levelmanager;
	private bool isBreakable;
	
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		timesHit = 0;
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
		//checks breakable tag and if true adds to total count.
		if(isBreakable){ breakableCount ++;
									Debug.Log ("Total Blocks :" +breakableCount);}
		
		
	}
	// Update is called once per frame
	void Update () {
		
	}
	//checks block isBreakable and calls HandleHits method
	void OnCollisionEnter2D(Collision2D collision) {
			AudioSource.PlayClipAtPoint (crackSound, transform.position);
			if (isBreakable){
				HandleHits();
			}
	}
	//checks the number of max hits from sprite length(+1)
	//loads the correct sprite base on number of hits with Loadsprite method
	void HandleHits () {
		timesHit++;
		int	maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			breakableCount --;
			levelmanager.BrickDestroyed();
			Destroy(gameObject);
		}else{
			LoadSprites();
		}
	}
	//method for loading sprites based on times the block has been hit
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	//TODO Remove this method once we can actually win
	void SimulateWin (){
		levelmanager.LoadNextLevel ();
	}
}
