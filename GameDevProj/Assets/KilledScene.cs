using UnityEngine;
using System.Collections;

public class KilledScene : MonoBehaviour {

    public RandomSounds sounds;

    void Start()
    {
        sounds.PlayRandomClip(this.transform);
    }
}
