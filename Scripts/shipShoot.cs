using UnityEngine;
using System.Collections;

public class shipShoot : MonoBehaviour {

	//Private
	private float health = 500f; 
	//Public 
	public LevelManager levelManager; 

	void OnTriggerEnter2D(Collider2D col) { 
		laser shoot = col.gameObject.GetComponent<laser>(); 
		if (shoot) {
			shoot.hit(); 
			health -= shoot.getDamage(); 
			if (health <= 0){
				Destroy(gameObject); 
				levelManager.LoadNextLevel(); 
			}
		}
	}
}
