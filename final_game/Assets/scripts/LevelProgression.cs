using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour {
    private static int level;
    public bool finish = false;

	// Use this for initialization
	void Start () {
		level = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		if (finish)
        {
            level++;
            SceneManager.LoadScene(level);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finish = true;
        }
    }

    void setLevel(int num)
    {
        level = num;
        SceneManager.LoadScene(level);
    }
}
