using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour {
	private GameObject player;
    private static int level;
    public bool finish = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		level = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		if (finish)
        {
         //   level++;
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
			Invoke( "finishLevel", .45f);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
			this.GetComponent<AudioSource> ().Play ();
            finish = true;
        }
    }

	void finishLevel(){
		level++;
		SceneManager.LoadScene(level);
	}

    void setLevel(int num)
    {
        level = num;
        SceneManager.LoadScene(level);
    }
}
