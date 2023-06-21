using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UImanager : MonoBehaviour
{
    [SerializeReference] private GameObject gameOverScreen;
    [SerializeReference] private GameObject pauseScreen;
    [SerializeReference] private PlayerController playerControl;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (pauseScreen.activeInHierarchy) PauseGame(false);
            else PauseGame(true);
        }

        if (pauseScreen.activeInHierarchy)
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
    #region GameOver
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
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
