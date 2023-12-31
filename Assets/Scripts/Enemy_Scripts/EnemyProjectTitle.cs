using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectTitle : Enemy
{
    [SerializeField] private float Speed;
    [SerializeField] public bool hit;
    private BoxCollider2D coll;
    private float lifeTime;
    // Start is called before the first frame update
    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float bulletSpeed = Speed * Time.deltaTime ;
        transform.Translate(bulletSpeed, 0, 0);
        lifeTime += Time.deltaTime;
        if (lifeTime > 5) gameObject.SetActive(false);

        //lifeTime += Time.deltaTime;
        //if (lifeTime > 5) gameObject.SetActive(false);


    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {   
        if (!collision.CompareTag("Room") && !collision.CompareTag("Enemy"))
        {
            base.OnTriggerEnter2D(collision);
            hit = true;
            coll.enabled = false;
            gameObject.SetActive(false);
            
            //if(ani != null) an

        }
    }

    //xet vi tri cho bullet
    public void SetProjectTitleActive()
    {
        gameObject.SetActive(true);
        hit = false;
        coll.enabled = true;
        lifeTime = 0;
    }

    //private void Deactivate()
    //{
    //    gameObject.SetActive(false);
    //    //Debug.Log("da cham");
    //}
}
