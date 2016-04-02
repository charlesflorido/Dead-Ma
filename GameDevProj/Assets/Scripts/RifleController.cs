using UnityEngine;
using System.Collections;
using System;

public class RifleController : Weapon {

    public MuzzleFlashController muzzle;
    public int Ammo;


    // Use this for initialization
    void Start () {
        muzzle.AddAmmo(Ammo);
	}

    public override void Fire()
    {
        muzzle.fire(true);
      
    }

    public override void FireOn()
    {
        
    }

    public override void FireEnd()
    {
        muzzle.fire(false);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
    }

    public override string GetAmmoLeft()
    {
        return "" + muzzle.GetAmmo();
    }

    public override void AddAmmo(int num)
    {
        muzzle.AddAmmo(num);
    }

    public override void SetInaccuracy(int n)
    {
        muzzle.SetAdditionalInAccuracy(n);
    }
}
