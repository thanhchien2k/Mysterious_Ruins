using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIntro : MonoBehaviour
{
  
    private void OnEnable()
    {   

        if (transform.parent != null)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
