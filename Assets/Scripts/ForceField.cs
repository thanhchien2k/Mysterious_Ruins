using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    [SerializeField] private float Condition;
    public void OpenForceField() {
        this.gameObject.SetActive(false);
    }
}
