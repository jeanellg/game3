using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//based off of MyUnitySingleton code from 
public class GameAudio : MonoBehaviour {
//	private AudioSource audioS;
//	private float currentMusicTime; 
	private static GameAudio instance = null;
	public static GameAudio Instance{
		get {return instance; }
	}
	void Awake(){
		
		if (instance != null && instance != this){
			this.GetComponent<AudioSource> ().Stop ();
			if(instance.GetComponent<AudioSource>().clip !=  this.GetComponent<AudioSource>().clip){
				instance.GetComponent<AudioSource> ().clip = this.GetComponent<AudioSource> ().clip;
				instance.GetComponent<AudioSource> ().Play ();
			}
//			audioS.Stop ();
//			if (instance.audioS.clip != audioS.clip) {
//				instance.audioS.clip = audioS.clip;
//				instance.audioS.Play ();
//			}
			Destroy(this.gameObject);
			return;
		}
		else{
			instance = this;
			instance.GetComponent<AudioSource> ().Play ();
//			audioS.Play ();
		}
		DontDestroyOnLoad(this.gameObject);
	}
//	void Update(){
//		currentMusicTime = audioS.time;
//	}
//	void OnLevelWasLoaded(int level){
//		audioS.time = currentMusicTime;
//	}
}