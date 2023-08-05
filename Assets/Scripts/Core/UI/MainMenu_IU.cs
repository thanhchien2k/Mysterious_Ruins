using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_IU : MonoBehaviour
{
    #region MenuGame
    //private Transform myTransform;
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

    public void OpenUI(Transform _value)
    {
        _value.LeanScale(Vector2.one, 0.8f).setEaseInOutCubic();
    }
    public void CloseUI(Transform _value)
    {
        _value.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }

    public void OpenLeanScaleDelay(Transform _value)
    {
        _value.transform.localScale = Vector2.zero;
        _value.LeanScale(Vector2.one, 0.3f).setDelay(0.79f).setEaseInOutCubic();
        //myTransform = _value; 

    }

    public void OpenLeanScale(Transform _value)
    {
        _value.transform.localScale = Vector2.zero;
        _value.LeanScale(Vector2.one, 0.3f).setEaseInOutCubic();
        //myTransform = _value; 

    }

    private void OnCompleted()
    {
        //myTransform.transform.localScale = new Vector2(0.7f,0.7f);
        //myTransform.LeanScale(Vector2.one, 0.3f).setEaseInBack();
    }
    #endregion
}
