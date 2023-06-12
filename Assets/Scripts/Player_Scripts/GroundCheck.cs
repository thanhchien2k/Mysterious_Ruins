using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] Transform groundCheckBox;
    [SerializeField] LayerMask Ground;
    [SerializeField] LayerMask overGround;
    public bool groundCheck;
    public bool overGroundCheck;
    Vector2 center, sizeBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        center = groundCheckBox.position;
        sizeBox = new Vector2(1f, 0.15f);
        groundCheck = Physics2D.OverlapBox(center, sizeBox,0, Ground);

    }
}
