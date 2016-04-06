using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {

    public Zombie zombie;
    public bool AttackOnTriggered = false;
    public bool Triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player")
        {
            Triggered = true;

            if (AttackOnTriggered)
            {
                try
                {
                    zombie.Attack();
                }
                catch(System.NullReferenceException ex)
                {

                }
                
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "player")
        {
            Triggered = false;

            if (AttackOnTriggered)
            {
                try
                {
                    zombie.Walk();
                }
                catch (System.NullReferenceException ex)
                {

                }
            }
        }
    }
}
