using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMane_IU : MonoBehaviour
{
    [Header("Levels to Load")]
    [SerializeField] public string playGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog;

    #region MenuGame

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
    }

    public void LoadGameLevel()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);

        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChangeSoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void ChangeMusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion
}
