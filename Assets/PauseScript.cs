using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public static bool GamePaused = false;
    public GameObject pauseMenyUI;

    
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
       {
            
            if (GamePaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
            }
        }
        
    }

    void Pause()
    {
    
        pauseMenyUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;

    }
    public void Resume()
    {
        pauseMenyUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
      
    }
    public void GotoMeny()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
