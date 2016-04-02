using UnityEngine;
using System.Collections;
using System;

public class PistolController : Weapon
{
    public MuzzleFlashController muzzle;

    public override void AddAmmo(int num)
    {

    }

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

    public override string GetAmmoLeft()
    {
        return "∞";
    }

    public override void SetInaccuracy(int n)
    {
        muzzle.SetAdditionalInAccuracy(n);
    }
}
     
