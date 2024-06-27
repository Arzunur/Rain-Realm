using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenuPanel;

    public void Resume()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1; 
        //pauseMenuPanel.SetActive(false); 
        //isPaused = false;

        pauseMenuPanel.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).OnComplete(() => pauseMenuPanel.SetActive(false));
       
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0; 
        pauseMenuPanel.SetActive(true); 
        isPaused = true;
    }
}
