using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Moving : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject ways;
    [SerializeField] private bool isMove;
    [SerializeField] private bool isSmile;
    [SerializeField] private bool isLizard;
    private Transform[] WayPoints;
    private Animator ani;

    Vector3 targetPos;
    int pointIndex;
    int pointCount;
    public float waitDuration;
    int speedMultiplier = 1;

    private void Awake()
    {
        WayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.transform.childCount; i++)
        {
            WayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }

    private void OnEnable()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("run", true);
    }
    private void Start()
    {   
        pointCount = WayPoints.Length -1 ;
        pointIndex = 1;
        targetPos = WayPoints[pointIndex].transform.position;
        ani = GetComponent<Animator>();
        ani.SetBool("run", isMove);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isMove) EnemyMove();
    }

    private void EnemyMove()
    {
        var step = speedMultiplier* speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if (transform.position == targetPos)
        {
            NextPoint();
        }
    }
    private void NextPoint()
    {
        if (pointIndex == pointCount) pointIndex=-1;
        
        pointIndex += 1;
        targetPos = WayPoints[pointIndex].transform.position;
        StartCoroutine(WaitNextPoint());
        SmoothMove();
    }

    IEnumerator WaitNextPoint()
    {
        speedMultiplier = 0;
        if(!isLizard) ani.SetBool("run", false);
        yield return new WaitForSeconds(waitDuration);
        speedMultiplier = 1;
        if (!isLizard) ani.SetBool("run", true);
        transform.localRotation = WayPoints[pointIndex].transform.localRotation;
    }

    private void SmoothMove()
    {
        if (isSmile) {
            if (transform.position.x == WayPoints[pointIndex].transform.position.x)
            {
                if (transform.position.y > WayPoints[pointIndex].transform.position.y)
                    transform.position = new Vector2(transform.position.x, transform.position.y - 0.7f);
                else transform.position = new Vector2(transform.position.x, transform.position.y + 0.7f);
            }
            else
            {
                if (transform.position.x > WayPoints[pointIndex].transform.position.x)
                    transform.position = new Vector2(transform.position.x - 0.7f, transform.position.y);
                else transform.position = new Vector2(transform.position.x + 0.7f, transform.position.y);
            }
        }
        else if(isLizard)
        { 
            if(pointIndex==2|| pointIndex==3 ||pointIndex==6||pointIndex == 7)
            {
                ani.SetBool("run", false);
            }
            else
            {
                ani.SetBool("run", true);
            }
        }

    }
    
    public void SetIsMove(bool _value)
    {
        isMove = _value;
    }

    public void SetPointMoving()
    {
        pointIndex = 1;
        targetPos = WayPoints[pointIndex].transform.position;
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
    }
}
