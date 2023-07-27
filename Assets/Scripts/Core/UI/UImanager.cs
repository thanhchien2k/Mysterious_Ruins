using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UImanager : MonoBehaviour
{
    [SerializeReference] private GameObject gameOverScreen;
    [SerializeReference] private GameObject pauseScreen;
    [SerializeReference] private GameObject pauseScreenDialog;
    [SerializeReference] private GameObject overScreenDialog;

    [SerializeReference] private PlayerController playerControl;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (pauseScreen.activeInHierarchy) PauseGame(false);
            else PauseGame(true);
        }

        if (pauseScreen.activeInHierarchy || pauseScreenDialog.activeInHierarchy || gameOverScreen.activeInHierarchy || overScreenDialog.activeInHierarchy)
        {
            Time.timeScale = 0;
            if (playerControl != null)
            {
                playerControl.enabled = false;
            }
        }
        //else
        //{
        //    Time.timeScale = 1;
        //    if (playerControl != null)
        //    {
        //        playerControl.enabled = true;
        //    }
        //}
    }
    #region GameOver
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        GameManager.instance.RestartLevel();
    }
    public void MainMenu()
    {
        GameManager.instance.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        GameManager.instance.NextLevel();
    }
    #endregion

    #region GamePause
    public void PauseGame(bool _staus)
    {
        pauseScreen.SetActive(_staus);
        if (_staus)
        {
            Time.timeScale = 0;
            if (playerControl != null)
            {
                playerControl.enabled = false;
            }
        }
        else 
        { 
            Time.timeScale = 1;
            if (playerControl != null)
            {
                playerControl.enabled = true;
            }
        }
    }
    
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }    
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion


}
