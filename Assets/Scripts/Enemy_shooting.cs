using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooting : MonoBehaviour
{
    private Animator ani;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBall;
    public void enemyShooting()
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
}
