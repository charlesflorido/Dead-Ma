using UnityEngine;
using System.Collections;

public class DeadlyProjectile : MonoBehaviour {
    public int damage = 2;
    public RandomSounds sounds;

    void Start()
    {
        try
        {
            sounds.PlayRandomClip(this.transform);
        }
        catch (System.Exception)
        {

        }
    }

    void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

}
