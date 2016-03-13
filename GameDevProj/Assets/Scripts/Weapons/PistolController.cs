using UnityEngine;
using System.Collections;
using System;

public class PistolController : Weapon
{
    public MuzzleFlashController muzzle;

    public override void Fire()
    {
        muzzle.fire(true);
    }

    public override void FireEnd()
    {
        muzzle.fire(false);
    }

    public override void FireOn()
    {
        
    }
}
