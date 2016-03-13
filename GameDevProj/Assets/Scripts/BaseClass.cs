using UnityEngine;

public abstract class BaseClass : MonoBehaviour {

    // Update is called once per frame

    void Update () {
        if (GameGlobals.Play)
        {
            Run();
        }
	}

    public abstract void Run();
    

    
}
