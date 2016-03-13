using UnityEngine;
using System.Collections;
using System;

public abstract class Weapon : BaseClass
{
    public AudioClip audioLoad;

    public override void Run()
    {

    }

    public abstract void Fire();
    public abstract void FireOn();
    public abstract void FireEnd();

    public void Load()
    {
        AudioSource.PlayClipAtPoint(audioLoad, this.gameObject.transform.position);
    }
}
