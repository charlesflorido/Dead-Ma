using UnityEngine;
using System.Collections;
using System;

public class Spit : BaseClass {

    public BlueExplosion exp;
    public float speed;
    public int damage = 0;

    private Animator anim;

    private Vector2 vel;
    private bool initalized = false;
    public AudioClip sound;

    void Start()
    {
        anim = GetComponent<Animator>();

        try
        {
            AudioSource.PlayClipAtPoint(sound, this.transform.position);
        }
        catch (System.Exception)
        {

        }
    }

    public override void Run()
    {
        if (initalized)
        {
            transform.position += new Vector3(vel.x, vel.y, 0.0f) * speed * Time.deltaTime;
        }
    }

    public void setVelocity(Vector2 vel)
    {
        this.vel = vel;
        initalized = true;
    }




    void Destroy()
    {
        if (exp != null)
        {
            Instantiate(exp, transform.position, Quaternion.identity);
        }
        GameObject.Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "player")
        {
            Destroy();
        }

        if(coll.gameObject.tag == "obs")
        {
            Destroy();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy();
    }

    
}
