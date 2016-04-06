using UnityEngine;
using System.Collections;

public class Spider : Zombie {

    public Spit projectile;
    public Transform projectileStart;
    public Transform target;

    void Start()
    {
       
    }

    void Update()
    {
        zombieHealth.UpdateValue(life);
    }


    public override void Attack()
    {
        GetComponent<Animator>().SetBool("attack", true);

    }

    public override void Walk()
    {
        GetComponent<Animator>().SetBool("attack", false);

    }

    void ThrowPunches()
    {

        Vector3 pos = target.position;

        Vector3 dir = this.transform.position - pos;
        float angle = 0.0f;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle -= 90.0f;

        Spit fire_bullet = Instantiate(projectile, transform.position, Quaternion.identity) as Spit;
        fire_bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float speedX = Mathf.Cos(Mathf.Deg2Rad * (angle - 90)) ;
        float speedY = Mathf.Sin(Mathf.Deg2Rad * (angle - 90)) ;



        fire_bullet.setVelocity(new Vector2(speedX, speedY));
    }

    public override void Death()
    {
        GetComponent<Destructible>().KillZombie();
    }

    public override void TakeDamage(float x)
    {
        ReduceHealth(x);

        if (life <= 0.0f)
        {
            Death();
            return;
        }
    }
}
