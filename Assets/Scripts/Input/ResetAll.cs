using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetAll : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActions;
    [SerializeField] private string _targetControlScheme;

    public void ResetAllBinding()
    {
        foreach(InputActionMap temp in _inputActions.actionMaps)
        {
            temp.RemoveAllBindingOverrides();
        }
    }

    public void ResetControlScheme()
    {
        foreach(InputActionMap map in _inputActions.actionMaps)
        {
            foreach (InputAction action in map.actions)
            {
                action.RemoveBindingOverride(InputBinding.MaskByGroup(_targetControlScheme));
            }
        }

    }
}
