using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator ani;
    private PlayerController playerController;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject [] bullets;

    [Header("Sound")]
    [SerializeField]private AudioClip shootSound;
    private Player_Item Items;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        Items = GetComponent<Player_Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerController.canRunAttack() && Items.GetBullet()>0 )
        {
            runAttack();
            Items.subBullet(1);
            
        }
        else if(Input.GetKeyDown(KeyCode.F) && playerController.canAttack() && Items.GetBullet() > 0)
        {
            Attack();
            Items.subBullet(1);
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
