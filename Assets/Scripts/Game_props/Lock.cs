using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private Button_Ground button;
    [SerializeField] private float speed;
    [SerializeField] private float distanceToMove = 2f;

    private Vector3 startingPosition;
    private Vector3 targetPosition;
    private void Start()
    {
        startingPosition = transform.position;
        targetPosition = startingPosition + (Vector3.up * distanceToMove);
    }

    private void Update()
    {
        if (button.GetIsHover() && transform.position != targetPosition)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
        }
    }

}
