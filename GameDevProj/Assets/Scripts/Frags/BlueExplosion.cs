using UnityEngine;
using System.Collections;

public class BlueExplosion : MonoBehaviour {

	void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
