using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	//Static
	static MusicPlayer instance = null;
	//Private 
	private AudioSource music;
	//Public 
	public AudioClip startClip; 
	public AudioClip gameClip; 
	public AudioClip loseClip;
		
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>(); 
			music.clip = startClip; 
			music.loop = true; 
			music.Play(); 
		}
		
	}
	
	void OnLevelWasLoaded(int level) {
		music.Stop(); 
		if (level == 0) {
			music.clip = startClip; 
		} else if (level == 1) {
			music.clip = gameClip; 
		} else if (level == 2) {
			music.clip = loseClip; 
		}
		music.loop = true; 
		music.Play(); 	
	}
}
