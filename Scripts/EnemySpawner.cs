using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	//Private
	private float speed = 5f;
	private bool movingRight = true;  
	private float min, max;  
	private float delay = 0.5f; 
	//Public
	public GameObject enemyPrefab; 
	public float width; 
	public float height; 

	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z; 
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)); 
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)); 
		min = leftMost.x; 
		max = rightMost.x;  
		CreateFormationUntillFull(); 
	}
	
	void CreateFormationUntillFull() {
		Transform freePosition = NextFreePosition(); 
		if (freePosition) {
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject; 
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition()) {
			Invoke("CreateFormationUntillFull", delay);
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height)); 			
	} 
	
	void Update () {
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float leftEdgeFormation = transform.position.x - (0.45f * width); 
		float rightEdgeFormation = transform.position.x + (0.45f * width); 		
		if (leftEdgeFormation < min) {
			movingRight = true; 
		} else if (rightEdgeFormation > max) {
			movingRight = false; 
		}
		
		if (AllMembersDead()) {
			CreateFormationUntillFull(); 
		}
	}
	
	Transform NextFreePosition() {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null; 
	}
	
	bool AllMembersDead() {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}	  
		}
		return true; 
	}
}