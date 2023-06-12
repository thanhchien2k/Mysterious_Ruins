using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    //private Rigidbody2D rb;
    private Animator ani;
    private Transform currentPoint;
    [SerializeField] bool move;
    [SerializeField] private bool moveUpDown;
    public float speedX, speedY;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        currentPoint = rightPoint.transform;
        ani.SetBool("run", move);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            enemiesMove();
        }


    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void enemiesMove()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint.transform == rightPoint.transform)
        {
            //rb.velocity = new Vector2(speedX, speedY);
            transform.position = new Vector3(transform.position.x + speedX * Time.deltaTime, transform.position.y + speedY * Time.deltaTime, transform.position.z);

        }
        else
        {
            //rb.velocity = new Vector2(-speedX, -speedY);
            transform.position = new Vector3(transform.position.x - speedX * Time.deltaTime, transform.position.y - speedY * Time.deltaTime, transform.position.z);

        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == rightPoint.transform)
        {
            flip();
            currentPoint = leftPoint.transform;

        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == leftPoint.transform)
        {
            flip();
            currentPoint = rightPoint.transform;

        }
    }
}
