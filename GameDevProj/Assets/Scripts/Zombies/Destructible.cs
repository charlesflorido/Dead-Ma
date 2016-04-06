using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

    public DeathScene scene;
    public AudioClip deathSound;

    void Start()
    {
        UserManager.instance.AddZombie();
    }

    public void KillZombie()
    {
        Instantiate(scene, transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject);

        try
        {
            AudioSource.PlayClipAtPoint(deathSound, this.transform.position);
        }catch(System.Exception ex)
        {

        }

        UserManager.instance.RemoveZombie();
    }
}
