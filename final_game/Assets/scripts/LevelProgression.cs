using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour {
    private static int level = 0;
    private bool finish = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (finish)
        {
            level++;
            print(level);
            SceneManager.LoadScene("level " + level);
            finish = false;
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
        SceneManager.LoadScene("level " + level);
    }
}
