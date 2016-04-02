using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public AudioClip audioExplode;
	
    void ExplosionSound()
    {
        AudioSource.PlayClipAtPoint(audioExplode, this.transform.position);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
