using UnityEngine;
using System.Collections;

public class Rocket : BaseClass
{

    public Explosion explosion;
    public float speed;
    public int damage = 0;

    private Animator anim;

    private Vector2 vel;
    private bool initalized = false;

    void Start()
    {
        anim = GetComponent<Animator>();
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

    void OnCollisionEnter2D(Collision2D target)
    {
        initalized = false;
        Explode();
        destroy();
    }

    void destroy()
    {
        Destroy(gameObject);
    }

    void Explode()
    {
        if (explosion)
        {
            Explosion exp = Instantiate(explosion, transform.position, Quaternion.identity) as Explosion;
        }
    }
}
