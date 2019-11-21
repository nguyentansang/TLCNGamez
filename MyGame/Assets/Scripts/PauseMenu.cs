using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    private bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (pause == false) {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void resume()
    {
        pause = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
    }
}
