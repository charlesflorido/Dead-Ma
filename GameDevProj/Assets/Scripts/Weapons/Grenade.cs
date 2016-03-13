using UnityEngine;
using System.Collections;
using System;

public class Grenade : BaseClass {

    private Rigidbody2D rigidBody;
    public Vector2 velocity;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public override void Run()
    {

    }
    
    public  

    void OnCollisionEnter2D(Collision2D target)
    {
        velocity = -velocity;
        rigidBody.AddForce(velocity);
    }



}
