using UnityEngine;
using System.Collections;

public class ProjectileImpact : MonoBehaviour {

    public AudioClip sound;

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "projectile")
        {

            AudioSource.PlayClipAtPoint(sound, this.gameObject.transform.position);
        }
    }
}
