using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] Transform groundCheckBox;
    [SerializeField] LayerMask Ground;
    public bool groundCheck;
    Vector2 center, sizeBox;

    void Update()
    {
        center = groundCheckBox.position;
        sizeBox = new Vector2(0.5f, 0.02f);
        groundCheck = Physics2D.OverlapBox(center, sizeBox,0, Ground);

    }
}
