using UnityEngine;
using System.Collections;
using System;

public class RPGController : Weapon {

    public Smoke smoke;
    public int Ammo;

    // Use this for initialization
    void Start()
    {
        smoke.AddAmmo(Ammo);
    }

    public override void AddAmmo(int num)
    {
        smoke.AddAmmo(num);
    }

    public override void Fire()
    {
        smoke.fire(true);
    }

    public override void FireEnd()
    {
        smoke.fire(false);
    }

    public override void FireOn()
    {
        
    }

    public override string GetAmmoLeft()
    {
        return smoke.GetAmmo() + "";
    }

    public override void SetInaccuracy(int n)
    {
        
    }

    
	
	
}
