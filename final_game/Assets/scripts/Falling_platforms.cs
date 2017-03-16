using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_platforms : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D thing){
		this.GetComponent<AudioSource> ().Play ();
	}
}
