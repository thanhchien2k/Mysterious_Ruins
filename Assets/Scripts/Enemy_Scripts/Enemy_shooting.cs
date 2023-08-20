using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Enemy_shooting : Enemy
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBall;
    [SerializeField] private float delayShootingTime;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
        ani.speed = 1;
    }
    private void EnemyShooting()
    {
            fireBall[selectFireBall()].transform.position = firePoint.transform.position;
            fireBall[selectFireBall()].GetComponent<EnemyProjectTitle>().SetProjectTitleActive();
    }

    private int selectFireBall()
    {
        for (int i = 0; i < fireBall.Length; i++)
        {
            if (!fireBall[i].activeInHierarchy)
                return i;
        }

        return 0;
    }

    private IEnumerator DelayShooting()
    {
        ani.speed = 0;
        yield return new WaitForSeconds(delayShootingTime);
        ani.speed = 1;
    }

    protected override void Die()
    {
        base.Die();
        ani.SetTrigger("die");
        gameObject.GetComponent<Enemy>().enemyDamage = 0;
        SoundManager.instance.PlaySound(explosionSound);
    }

    private void Deactive()
    {
        gameObject.SetActive(false);
    }


}
