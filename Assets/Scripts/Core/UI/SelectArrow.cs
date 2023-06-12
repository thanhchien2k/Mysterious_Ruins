using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class SelectArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip selectSound;
    private int currentPosition;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeSelectionArrow(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeSelectionArrow(1);

        if (Input.GetKeyDown(KeyCode.Return)) Interact();
    }
    private void ChangeSelectionArrow(int _change)
    {
        currentPosition += _change;

        if (_change != 0) SoundManager.instance.PlaySound(changeSound);
        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;
        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }

    private void Interact()
    {
        SoundManager.instance.PlaySound(selectSound);

        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}
