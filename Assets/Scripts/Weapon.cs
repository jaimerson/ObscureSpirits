using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Player player;
    public float power = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(!player.IsAttacking()) { return; }

        GameObject target = other.gameObject;
        if(target.CompareTag("enemy")){
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.TakeHit(power);
        }
    }
}
