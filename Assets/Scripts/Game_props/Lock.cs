using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private Button_Ground button;
    [SerializeField] private float speed;
    [SerializeField] private float distanceToMove = 2f;
    private Player_Item playerItem;
    [SerializeField] private GameObject computer;

    private Vector3 startingPosition;
    private Vector3 targetPosition;
    private void Start()
    {
        startingPosition = transform.position;
        targetPosition = startingPosition + (Vector3.up * distanceToMove);
        playerItem = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Item>();

    }

    private void Update()
    {
        if (button.GetIsHover() && transform.position != targetPosition )
        {
           
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
        }
        if(button == null || !button.gameObject.activeSelf || computer!=null)
        {
            if (playerItem.GetPower() == playerItem.GetMaxPower() && DialogueManager.isMessageActive
                && computer.gameObject.GetComponent<NPC>().GetIsDiaLogue())
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }

}
