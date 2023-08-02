using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainMenu_IU : MonoBehaviour
{
    #region MenuGame

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        GameManager.instance.ResetGame();
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
