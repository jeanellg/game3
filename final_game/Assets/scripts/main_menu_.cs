using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class main_menu_ : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Start_button()
    {
        SceneManager.LoadScene(2);
    }

    public void back_to_main()
    {
        SceneManager.LoadScene(0);
    }

    public void instructions()
    {
        SceneManager.LoadScene(1);
    }
    
    public void quit()
    {
        Application.Quit();
    }
}
