using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item : MonoBehaviour
{
    public float playerBullet;
    public float maxBullet;
    //public float startingBullet;
    [SerializeField] public float power;
    public float maxPower;
    // Start is called before the first frame update
    void Start()
    {
        
        power = 0;
        playerBullet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addBullet(float _value)
    {
        playerBullet =Mathf.Clamp(playerBullet + _value, 0, maxBullet);
    }

    public void subBullet(float _value)
    {
        playerBullet = Mathf.Clamp(playerBullet - _value, 0, maxBullet);
    }
    public void addPower(float _value)
    {
        power = Mathf.Clamp(power + _value, 0, maxPower);
    }
}
