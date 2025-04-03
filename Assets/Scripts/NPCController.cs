using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    //My components
    public Rigidbody RB;
    //public Animator Anim;
    public float health = 2;
    public BoxCollider boxCollider;

    //My stats
    public float Speed = 1;
    
    //Who do I walk towards?
    public GameObject Target;

    public float jumpTime;
    public float lastJumpTime;
    public float jumpVel;
    public bool dead;
    public GameManager gameManager;



    void Start()
    {
        //At the start of the game I should play my walk animation
        //Anim.Play("Walking");
        //I just walk forever, for now.
        health = 2 + gameManager.timer / 40.0f;


    }

    private void Update()
    {
        if (health > 0)
        {
            if (!menuScript.paused)
            {
                //Rotate to look at the player
                transform.LookAt(Target.transform);
                //Make a temp velocity variable to calculate how I should move
                //By default, I keep my old momentum
                Vector3 vel = RB.linearVelocity;
                //Walk forwards, but don't do it perfectly. Lerp towards my desired speed
                //This makes it so that if I take a knockback it takes a second for me to recover
                vel = Vector3.Lerp(vel, transform.forward * (Speed + gameManager.timer / 18.0f), 10 * Time.deltaTime);
                //Use my old Y velocity, though. I shouldn't be able to fly
                vel.y = RB.linearVelocity.y;
                //Plug it into my rigidbody
                RB.linearVelocity = vel;
            }

            if(transform.position.y<=1.5f) lastJumpTime -= Time.deltaTime;
            if(lastJumpTime <= 0){
            Jump();
            lastJumpTime = jumpTime;
            }
            if (transform.position.y < -20 && !dead) Die();
        }
        else if(!dead) Die();
    }

    public void Die()
    {
        dead = true;
        boxCollider.isTrigger = true;
         Destroy(gameObject, 2.0f);
        Vector3 launchVel = Vector3.forward * -3;
        RB.linearVelocity += launchVel;
        gameManager.kills++;
    }

    public void Jump(){
        Vector3 vel = new Vector3(0, jumpVel + gameManager.timer/20.0f, 0);
        RB.linearVelocity += vel;
    }
}
