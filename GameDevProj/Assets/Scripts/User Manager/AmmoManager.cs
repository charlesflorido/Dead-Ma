using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoManager : MonoBehaviour {

    public Text ammo;

    public void UpdateAmmo(string s)
    {
        ammo.text = s;
    }
}
