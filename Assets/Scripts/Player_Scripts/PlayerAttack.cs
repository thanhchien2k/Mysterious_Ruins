using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{

    private Animator ani;
    private PlayerController playerController;
    [SerializeField] private Transform bulletPoint;
    private List<GameObject> bullets;
    [SerializeField] private GameObject bulletHolder;
    private float tempBulletLifeTime = 5f;
    [SerializeField] private GameObject bulletPrefabs;
    

    [Header("Sound")]
    [SerializeField]private AudioClip shootSound;
    private Player_Item Items;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        Items = GetComponent<Player_Item>();

        bullets = new List<GameObject>();

        for (int i = 0; i < bulletHolder.transform.childCount; i++)
        {
            bullets.Add(bulletHolder.transform.GetChild(i).gameObject);
        }
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
        int Counter = 0;
        for (int i=0 ; i < bullets.Count; i++)
        {   
            if (!bullets[i].activeInHierarchy) return i;
            Counter += 1;

        }

        if (Counter >= bullets.Count)
        {   
            GameObject tempBullet = Instantiate(bulletPrefabs, bulletPoint.position, Quaternion.identity, bulletHolder.transform);
            bullets.Add(tempBullet);
            StartCoroutine(DestroyTempBullet(tempBullet));
            return bullets.IndexOf(tempBullet);
        }

        return 0;
        
    }

    private IEnumerator DestroyTempBullet(GameObject tempBullet)
    {
        yield return new WaitForSeconds(tempBulletLifeTime);
        bullets.Remove(tempBullet);
        Destroy(tempBullet);
    }
}
