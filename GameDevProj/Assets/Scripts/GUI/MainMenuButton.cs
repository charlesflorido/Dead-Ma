using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler {

    public AudioSource audioClick;
    public AudioSource audioHover;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        audioClick.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        audioHover.Play();
    }
}
