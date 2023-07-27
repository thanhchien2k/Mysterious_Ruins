using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelMenu : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject levelButton;

    private void Awake()
    {
        ButtonToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        
        for (int i=0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }

    }

    public void OpenLevel(int _index)
    {
        GameManager.instance.OpenLevel(_index);
    }

    void ButtonToArray()
    {
        int childCount = levelButton.transform.childCount;
        buttons = new Button[childCount];
        for(int i =0; i < childCount; i++)
        {
            buttons[i] = levelButton.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }

    public void UpdateButtonActive()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        Debug.Log(unlockedLevel);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }

        
    }

}
