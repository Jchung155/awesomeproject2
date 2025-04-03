using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3DController : MonoBehaviour
{
    //My components
    public Rigidbody RB;
    
    //How fast do I fly?
    public float Speed = 30;
    //How hard do I knockback things I hit?
    public float Knockback = 10;
    public FirstPersonController player;

    void Start()
    {
        //When I spawn, I fly straight forwards at my Speed
        RB.linearVelocity = transform.forward * (Speed + player.bulletSpeedUpgrade);
    }

    private void OnCollisionEnter(Collision other)
    {
        //If I hit something with a rigidbody. . .
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        NPCController enemyController = other.gameObject.GetComponent<NPCController>();
        if (rb != null && other.gameObject.tag == "Enemy")
        {
            //I push them in the direction I'm flying with a power equal to my Knockback stat
            rb.AddForce(RB.linearVelocity.normalized * (Knockback + player.knockbackUpgrade),ForceMode.Impulse);
        }
        if(enemyController != null)
        {
            enemyController.health-= player.damage;
        }
        //If I hit anything, I despawn
        Destroy(gameObject);
    }
}
