using UnityEngine;
using System.Collections;
using System;

public class BombController : Weapon
{

    public AudioClip setAlarm;


    public override void AddAmmo(int num)
    {
        
    }

    public override void Fire()
    {
        AudioSource.PlayClipAtPoint(setAlarm, this.transform.position);
    }

    public override void FireEnd()
    {
        
    }

    public override void FireOn()
    {
        
    }

    public override string GetAmmoLeft()
    {
        return "";
    }

    public override void SetInaccuracy(int n)
    {
        
    }
}
