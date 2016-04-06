using UnityEngine;
using System.Collections;

[System.Serializable]
public class RandomSounds{

    public AudioClip[] audioClips;
    private int start = 0;

    public void PlayRandomClip(Transform trans)
    {
        if(audioClips.Length > 0)
        {
            int x = Random.Range(0, audioClips.Length - 1);
          
            AudioSource.PlayClipAtPoint(audioClips[x], trans.position, 2.0f);
        }
    }

    public void PlayLinearClip(Transform trans)
    {
        if(audioClips.Length > 0)
        {
            start++;
            start = start % audioClips.Length;

            AudioSource.PlayClipAtPoint(audioClips[start], trans.position);

        }
    }

}
