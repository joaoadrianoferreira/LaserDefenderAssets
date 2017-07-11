using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) { 
		Destroy(col.gameObject); 
	}
}
