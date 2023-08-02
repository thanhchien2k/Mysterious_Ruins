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
        SetTimeScale(1);
    }

    public void LoadScene(int _index)
    {
        SceneManager.LoadScene(_index);
        SetTimeScale(1);
    }

    public void OpenLevel(int levelID)
    {
        string LevelName = "Level " + levelID;
        SceneManager.LoadScene(LevelName);
        SetTimeScale(1);
    }

    public void NextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        OpenLevel(int.Parse(currentSceneName[currentSceneName.Length - 1].ToString())+1);
        SetTimeScale(1);
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

    public void ResetGame()
    {
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        PlayerPrefs.SetInt("ReachedIndex", 1);
        PlayerPrefs.Save();
        SoundManager.instance.ResetVolume();
    }

    public void OpenUI(Transform _value)
    {
        _value.LeanScale(Vector2.one, 0.8f);
    }
    public void CloseUI(Transform _value)
    {
        _value.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }

    private void SetTimeScale(int _value)
    {
        Time.timeScale = _value;
    }
}
