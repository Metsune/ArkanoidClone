using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	bool gameStarted = false;
	
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStarted == false) {
			
			this.transform.position = paddle.transform.position + paddleToBallVector; // holds ball on paddle
		
			if(Input.GetMouseButtonDown(0)){ //releases ball on mouseclick
				print ("mouse clicked, launch ball");
				gameStarted = true; // sets game state to true
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			} 
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		
		if(gameStarted == true){
		this.GetComponent<AudioSource>().Play ();
		this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
	
}
