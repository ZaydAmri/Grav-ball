using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour {

    public BallParentScript ballParent;
    public GameObject panelPause, panelWin, panelGameOver;
    public string nextLevel;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void JumpButton()
    {
        ballParent.Jump();
    }
    public void JumpButtonUp()
    {
        ballParent.ButtonJumpUp();
    }
    public void GravityButton()
    {
        ballParent.ChangeGravity();
    }
    public void DivisionButton()
    {
        ballParent.Division();
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }

    public void ReturnFromPausePanel()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }
    public void HomeButton()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
    public void ReplayButton()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        Time.timeScale = 0;
        panelWin.SetActive(true);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
    }
}
