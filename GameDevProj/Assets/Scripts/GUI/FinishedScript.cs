using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishedScript : MonoBehaviour {

    public int level;

    void Update()
    {
        GetComponent<Text>().text = "Finished level " + level + " in " + GameGlobals.Finished + " seconds. Congratulations";
    }
}
