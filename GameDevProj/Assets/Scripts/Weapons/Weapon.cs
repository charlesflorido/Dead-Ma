using UnityEngine;
using System.Collections;
using System;

public abstract class Weapon : BaseClass
{
    public AudioClip audioLoad;
    public float Weight = 0.0f;

    public override void Run()
    {

    }

    public abstract void Fire();
    public abstract void FireOn();
    public abstract void FireEnd();
    public abstract string GetAmmoLeft();
    public abstract void AddAmmo(int num);

    public void Load()
    {
        AudioSource.PlayClipAtPoint(audioLoad, this.gameObject.transform.position);
    }


    public abstract void SetInaccuracy(int n);
   
}
