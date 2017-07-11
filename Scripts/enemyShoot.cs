using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class enemyShoot : MonoBehaviour {
	
	//Private 
	private float health = 200f; 
	private float laserSpeedEnemy = 5f; 
	private float shootsPerSecond = 0.5f;
	private Text scoreText; 
	private scoreKeeper score;
	//Public 
	public GameObject laser;
	public AudioClip fireSound; 
	public AudioClip deathSound; 
	 
	
	void Start() {
		scoreText = GameObject.FindObjectOfType<Text>();
	}

	void OnTriggerEnter2D(Collider2D col) { 
		laser shoot = col.gameObject.GetComponent<laser>(); 
		if (shoot) {
			shoot.hit(); 
			health -= shoot.getDamage(); 
			if (health <= 0){
				Destroy(gameObject);
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
				int oldScore = scoreKeeper.getScore();       
				scoreKeeper.Score(oldScore + 10); 
				scoreText.text = "Score: " + scoreKeeper.getScore() + " pts"; 
			}
		}
	}
	
	void fire() {
		Vector3 startPosition = transform.position + new Vector3 (0f, -1f, 0f); 
		GameObject shoot = Instantiate(laser, startPosition, Quaternion.identity) as GameObject; 
		shoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -laserSpeedEnemy); 
	}
	
	void Update() {
		float prob = shootsPerSecond * Time.deltaTime;
		if (Random.value < prob) {
			fire (); 
			AudioSource.PlayClipAtPoint(fireSound, transform.position); 
		} 
	}
}
