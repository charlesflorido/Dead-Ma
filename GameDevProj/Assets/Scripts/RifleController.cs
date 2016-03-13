using UnityEngine;
using System.Collections;
using System;

public class RifleController : Weapon {

    public MuzzleFlashController muzzle;

    // Use this for initialization
    void Start () {
	
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

    



}
