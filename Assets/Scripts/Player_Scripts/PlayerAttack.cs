using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator ani;
    private PlayerController playerController;
    private Player_Item playerItem;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject [] bullets;

    [Header("Sound")]
    [SerializeField]private AudioClip shootSound;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerController.canRunAttack() )
        {
            runAttack();
            
        }
        else if(Input.GetKeyDown(KeyCode.F)  )
        {
            Attack();
            

        }
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(shootSound);
        ani.SetTrigger("attack");
        //pooling bullet
        bullets[selectBullet()].transform.position = bulletPoint.position;
        bullets[selectBullet()].GetComponent<ProjectTitle>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private void runAttack()
    {
        SoundManager.instance.PlaySound(shootSound);
        ani.SetTrigger("runAttack");
        bullets[selectBullet()].transform.position = bulletPoint.position;
        bullets[selectBullet()].GetComponent<ProjectTitle>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int selectBullet()
    {
        for(int i=0 ; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }

        return 0;
    }
}
