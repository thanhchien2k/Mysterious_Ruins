using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Hidden : MonoBehaviour
{
    [SerializeField] private Button_Ground button;
    private bool isActive = false;
    private Animator ani;
    [SerializeField] private float delayTime;
    [SerializeField]private bool delayMode;
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        ani.speed = 0;
    }

    private void Update()
    {
        if (button.GetIsHover() && !isActive )
        {
            ani.speed = 1;
            isActive = true;
        }
    }

    private IEnumerator DelayAniamtion()
    {
        ani.speed = 0;
        yield return new WaitForSeconds(delayTime);
        ani.speed = 1;
    }

    private void DelayMode()
    {
        if (delayMode)
        {
            StartCoroutine(DelayAniamtion());
            delayMode = false;
        }
    }
}
