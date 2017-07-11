using UnityEngine;
using System.Collections;

public class scoreKeeper : MonoBehaviour {

	//Static
	private static int score = 0;
	
	public static void Score(int newScore) {
		score = newScore; 
	} 
	
	public static int getScore() {
		return score; 
	}
	
	public static void Reset() {
		score = 0; 
	}
}
