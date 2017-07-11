using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Private
	private float speed = 10.0f; 
	private float min, max; 
	private float padding = 0.5f; 
	private float laserSpeed = 5f; 
	private float  firingRate = 0.2f; 
	//Public
	public GameObject laser; 
	public AudioClip fireSound; 

	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z; 
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)); 
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)); 
		min = leftMost.x + padding; 
		max = rightMost.x - padding;  
	}
	
	void fire() {
		Vector3 startPosition = transform.position + new Vector3 (0f, 1f, 0f); 
		GameObject laserBeam = Instantiate(laser, startPosition, Quaternion.identity) as GameObject; 
		laserBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f,laserSpeed); 
		AudioSource.PlayClipAtPoint(fireSound, transform.position); 
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) { 
			transform.position += Vector3.left * speed * Time.deltaTime;  
		}  else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right	 * speed * Time.deltaTime;
		}
		
		float newX = Mathf.Clamp(transform.position.x, min, max); 
		transform.position = new Vector3(newX, transform.position.y, transform.position.z); 
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("fire", 0.00001f, firingRate); 
		} else if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("fire"); 
		}
	}
}
