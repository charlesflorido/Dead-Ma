using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {
    public Zombie zombie;
    public bool attackOnTouch = true;

    void OnCollisionStay2D(Collision2D coll)
    {
        if(attackOnTouch && coll.gameObject.tag == "player")
        { 
            zombie.Attack();
        }

        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "projectile")
        {
            Bullet bullet = coll.gameObject.GetComponent<Bullet>();
            zombie.TakeDamage(bullet.damage);
        }

        if(coll.gameObject.tag == "rocket")
        {
            zombie.TakeDamage(50f);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "player")
        {
            zombie.Walk();
         
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "explosion")
        {
             zombie.TakeDamage(50f);
        }
    }

    public void ShowHealth(bool show)
    {
        zombie.ShowHealth(show);
    }

}
