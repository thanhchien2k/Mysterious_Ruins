using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }

    public void OpenLevel(int levelID)
    {
        string LevelName = "Level " + levelID;
        SceneManager.LoadScene(LevelName);
    }

    public void NextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        OpenLevel(int.Parse(currentSceneName[currentSceneName.Length - 1].ToString())+1);
    }

    public void UnlockLevel()
    {

        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
