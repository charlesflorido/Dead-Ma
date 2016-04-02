using UnityEngine;
using System.Collections;
using System;

public class MachineGunController : Weapon
{
    public MuzzleFlashController muzzle;
    public int Ammo;

    void Start()
    {
        muzzle.AddAmmo(Ammo);
    }

    public override void AddAmmo(int num)
    {
        muzzle.AddAmmo(num);
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
        return "" + muzzle.GetAmmo();
    }

    public override void SetInaccuracy(int n)
    {
        muzzle.SetAdditionalInAccuracy(n);
    }
}
