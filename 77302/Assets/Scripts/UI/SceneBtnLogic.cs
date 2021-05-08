using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBtnLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBtnClick()
    {
        SceneManager.LoadScene("02-SelectLevel");
    }

    public void exitBtnClick()
    {
        Invoke("LeaveGame", 1f);
    }

    public void backBtnClick()
    {
        SceneManager.LoadScene("01-Opening");
    }

    public void aboutBtnClick()
    {
        SceneManager.LoadScene("05-About");
    }

    public void homeBtnClick()
    {
        SceneManager.LoadScene("01-Opening");
    }

    public void restart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void selectLevelBtnClick()
    {
        SceneManager.LoadScene(this.name.Remove(6,this.name.Length - 6));
        Time.timeScale = 1;
    }

    void LeaveGame()
    {
        Application.Quit();
    }
}
