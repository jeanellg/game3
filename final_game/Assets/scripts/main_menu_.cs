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
<<<<<<< HEAD
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
=======
        SceneManager.LoadScene("level 0");
>>>>>>> 7e43273e7090bda3c15249c461a7bd10690e675b
    }
}
