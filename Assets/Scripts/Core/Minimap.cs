using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    [SerializeField] RectTransform[] miniMapPos;
    [SerializeField] GameObject[] cameraList;
    [SerializeField] GameObject currentCamera;
    private RectTransform miniMapHover;
    private Animator ani;
    private bool anyCameraActive = false;


    private void Start()
    {
        miniMapHover = GetComponent<RectTransform>();
        miniMapHover.position = miniMapPos[0].position;
        ani = GetComponent<Animator>();

    }

    private void Update()
    {
        anyCameraActive = false;
        for(int i=0; i < cameraList.Length; i++)
        {
            if (cameraList[i].activeSelf)
            {
                miniMapHover.position = miniMapPos[i].position;
                anyCameraActive = true;
            }
        }

        if (!anyCameraActive)
        {
            miniMapHover.gameObject.GetComponent<Image>().enabled = false;
        }
        else
        {
            miniMapHover.gameObject.GetComponent<Image>().enabled = true;
        }
    }

}
