using UnityEngine;
using System.Collections;
using System;

public class WeakZombie : Zombie
{
    public DeadlyProjectile projectile;
    public Transform projectileStart;

    void Start()
    {
        zombieHealth.SetMaxValue(life);
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
        walkingSounds.PlayLinearClip(this.transform);
    }

    void ThrowPunches()
    {
        DeadlyProjectile p = Instantiate(projectile, projectileStart.position, Quaternion.identity) as DeadlyProjectile;
        p.transform.rotation = transform.rotation;
      
    }

    public override void Death()
    {
        GetComponent<Destructible>().KillZombie();
        deathSounds.PlayRandomClip(this.transform);
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
