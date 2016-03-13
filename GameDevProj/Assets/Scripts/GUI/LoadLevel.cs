using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class LoadLevel : MonoBehaviour {

    public FadingScene scene;

    public void ChangeScene(int level)
    {

        StartCoroutine(ChangeLevel(level));
    }


    IEnumerator ChangeLevel(int level)
    {
        float fadeTime = scene.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(level);
    }
}
