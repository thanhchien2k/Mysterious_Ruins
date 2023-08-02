using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTitle : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] public bool hit;
    [SerializeField] private float direction;
    private BoxCollider2D coll;
    private Animator ani;
    private float lifeTime;
    // Start is called before the first frame update
    void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float bulletSpeed = Speed * Time.deltaTime*direction;
        transform.Translate(bulletSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime >5) gameObject.SetActive(false);
        

    }

    private void OnTriggerEnter2D(Collider2D vc)
    {
        if (!vc.CompareTag("Room") && !vc.CompareTag("Heart") )
        {
            if (vc.CompareTag("Enemy"))
            {
                vc.gameObject.GetComponent<Enemy>().TakeDamage(1);
            }
            //Debug.Log(vc.gameObject.layer);
            hit = true;
            coll.enabled = false;
            ani.SetTrigger("isHit");

        }
    }

    //xet vi tri cho bullet
    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        //Debug.Log("ko on r");
        direction = _direction;
        gameObject.SetActive(true);
        hit = false; 
        coll.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction) localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX,transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}
