using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sound_Button : MonoBehaviour
{
    [SerializeField] AudioClip ClickSound;
    [SerializeField] AudioClip HoverSound;



    private void PlayClickSound()
    {
        SoundManager.instance.PlaySound(ClickSound);
    }

    private void  PlayHoverSound()
    {
        SoundManager.instance.PlaySound(HoverSound);
    }
}
