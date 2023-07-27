using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHiddenUI : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Vector2.zero;
        //gameObject.SetActive(false);
    }


    public void OpenUI()
    {
        transform.LeanScale(Vector2.one, 0.8f);
    }
    public void CloseUI()
    {
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }

}
