using UnityEngine;
using System.Collections;

public class DeathScene : MonoBehaviour {

	void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
