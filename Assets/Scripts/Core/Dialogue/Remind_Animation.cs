using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remind_Animation : MonoBehaviour
{
    [SerializeField] private CanvasGroup remind;

    private void Start()
    {
        LeanTween.alpha(gameObject, 0f, 0.5f).setLoopPingPong();
    }

}
