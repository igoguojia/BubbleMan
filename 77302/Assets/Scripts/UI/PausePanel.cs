using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public bool isPause = false;
    public GameObject pausePanel;

    public void PausePanelOpen()
    {
        Time.timeScale = 0;
        isPause = true;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isPause = false;
        pausePanel.SetActive(false);
    }

    public void BackLevel()
    {
        SceneManager.LoadScene("02-SelectLevel");
    }

    public void Home()
    {
        SceneManager.LoadScene("01-Opening");
    }

}
