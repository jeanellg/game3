using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    GameObject pauseMenu;
    GameObject restart_button;
    bool paused;
    // Use this for initialization
    void Start()
    {
        paused = false;
        pauseMenu = GameObject.Find("pauseMenu");
        restart_button = GameObject.Find("restart_button");


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }
        if (paused)
        {
            pauseMenu.SetActive(true);
            restart_button.SetActive(false);
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            pauseMenu.SetActive(false);
            restart_button.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        paused = false;
    }

    public void back_to_main()
    {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }
}
