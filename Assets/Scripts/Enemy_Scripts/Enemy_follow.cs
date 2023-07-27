using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_follow : MonoBehaviour
{
    private Transform player;

    public float speed ;
    public float shockedTime;
    public float lineOfSize;

    private float shockedTimer;
    private bool isChasing = true;
    private bool canShocked = true;

    public GameObject Camlimited;
    [SerializeField] GameObject defaultPosition;
    [SerializeField] private PlayerController playerController;
    Enemy_Moving enemyMoving;

    private Animator ani;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ani = GetComponent<Animator>();
        enemyMoving = gameObject.GetComponent<Enemy_Moving>();

    }

    // Update is called once per frame
    void Update()
    {   float distanceFromPlayer = Vector2.Distance(defaultPosition.transform.position,player.position);
        if (Camlimited.activeSelf && distanceFromPlayer<lineOfSize)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            enemyMoving.SetIsMove(false);
            flip();

            if ((player.localScale.x==this.transform.localScale.x || playerController.IsMove()) && isChasing ) {
                enemyFollowing();
                canShocked = true;
            }
            else
            {
                enemyStop();
            }

        }
        else
        { 
                if(transform.position.y != defaultPosition.transform.position.y)
                {
                MoveToDefaultPoint();
                enemyMoving.SetPointMoving();
                }
                else
                {
                transform.localScale = new Vector3(-1, 1, 1);
                enemyMoving.SetIsMove(true);
                }
                
        }


    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        
        if (this.transform.position.x - player.position.x >= 0)
        {

            localScale.x = 1;
 

        }
        else
        {
            localScale.x = -1;

        }
        transform.localScale = localScale;

    }
    private void enemyFollowing()
    {
        ani.SetBool("isFury",true);
        Vector2 followPosition = player.position ;
        followPosition.y -= 1;
        //if(this.transform.position.y > player.position.y)
        //{
        //    followPosition.y -= 1;
        //}
        //else
        //{
        //    followPosition.y += 1;
        //}


        if (this.transform.position.x - player.position.x > 0)
        {
            
             followPosition.x += 0.5f; 

        }
        else
        {
            
            followPosition.x -= 0.5f;
        }

        transform.position = Vector2.MoveTowards(this.transform.position, followPosition, speed * Time.deltaTime);
        

    }

    private void enemyStop()
    {

        if (canShocked)
        {
            if (shockedTimer > shockedTime)
            {
                shockedTimer = 0;
                ani.SetBool("isShocked", false);
                canShocked = false;

            }

            else
            {
                shockedTimer += Time.deltaTime;
                ani.SetBool("isShocked", true);
            }
        }
        
        ani.SetBool("isFury", false);
       
        isChasing = false;

        if (shockedTimer == 0)
        {
            if (playerController.IsMove() || player.localScale.x == this.transform.localScale.x)
            {
                isChasing = true;
            }
        }
    }

    private void MoveToDefaultPoint()
    {
        ani.SetBool("isFury", false);
        ani.SetBool("isShocked", false);

        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Vector3 localScale = transform.localScale;

        if (this.transform.position.x - defaultPosition.transform.position.x > 0)
        {

            localScale.x = 1;

        }
        else
        {
            localScale.x = -1;
        }
        transform.localScale = localScale;

        transform.position = Vector2.MoveTowards(this.transform.position, defaultPosition.transform.position, speed * Time.deltaTime);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(defaultPosition.transform.position, lineOfSize);
    }

}
