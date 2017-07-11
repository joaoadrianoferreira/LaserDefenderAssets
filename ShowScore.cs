using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class ShowScore : MonoBehaviour {

	private Text[] scoreText; 
	private int totalScore;  

	// Use this for initialization
	void Start () {
		scoreText = GameObject.FindObjectsOfType<Text>();
		totalScore = scoreKeeper.getScore();  
		scoreText[1].text = "Score: " + totalScore + " pts";
		scoreKeeper.Reset(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
