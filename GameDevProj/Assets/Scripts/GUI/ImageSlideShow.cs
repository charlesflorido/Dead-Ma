using UnityEngine;
using System.Collections;

public class ImageSlideShow : MonoBehaviour {

    public ImageSlideShow nextSlide;
    public bool startFirst;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetInteger("animState", (startFirst)?0:1);
    }

    void PlayNextSlide()
    {
        anim.SetInteger("animState", 1);
        nextSlide.PlaySlide();
    }

    public void PlaySlide()
    {
        anim.SetInteger("animState", 0);
    }
	
	
}
