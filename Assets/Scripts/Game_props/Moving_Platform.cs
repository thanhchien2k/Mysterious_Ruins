using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject ways;

    private Transform[] WayPoints;
    int pointIndex,pointCount;
    Vector3 targetPos;

    PlayerController playerControll;
    Rigidbody2D rb;
    Rigidbody2D playerRb;
    Vector3 moveDirection;

    private void Awake()
    {
        playerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();

        WayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.transform.childCount; i++)
        {
            WayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        pointCount = WayPoints.Length - 1;
        pointIndex = 1;
        targetPos = WayPoints[pointIndex].transform.position;
        DirectionCalculate();
    }

    private void Update()
    {
        platformMove();

    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    void DirectionCalculate()
    {
        moveDirection = (targetPos - transform.position).normalized;
    }

    private void platformMove()
    {
        if (Vector2.Distance(transform.position,targetPos)<0.05f)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        transform.position = targetPos;
        if (pointIndex == pointCount) pointIndex = -1;

        pointIndex += 1;
        targetPos = WayPoints[pointIndex].transform.position;
        DirectionCalculate();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerControll.isOnPlatform = true;
            playerControll.platformRb = rb;
            playerControll.SetGravetiScale(50f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerControll.isOnPlatform = false;
            playerControll.platformRb = rb;
            playerControll.SetGravetiScale(2.8f);

        }
    }
}
