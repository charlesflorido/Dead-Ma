using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
[RequireComponent (typeof(Animator))]
public class ZombieHealth : MonoBehaviour {

    private Slider slider;
    private Animator anim;


	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        anim = GetComponent<Animator>();
        slider.minValue = 0.0f;
	}

    public void SetMaxValue(float max)
    {
        try
        {
            GetComponent<Slider>().maxValue = max;
        }
        catch(System.NullReferenceException ex)
        {

        }
    }
	
	public void SetHealth(float x)
    {
        if(x >= slider.minValue && x <= slider.maxValue)
        {
            slider.value = x;
        }
  
    }

    public void ReduceHealth(float x)
    {
        if((slider.value - x) >= slider.minValue)
        {
            slider.value -= x;
        }
        else
        {
            slider.value = 0.0f;
        }
    }

    public void AddHealth(float x)
    {
        if ((slider.value + x) <= slider.minValue)
        {
            slider.value += x;
        }
        else
        {
            slider.value = slider.maxValue;
        }
    }

    public void ShowHealth(bool show)
    {
        anim.SetBool("show", show);
    }

    public void UpdateValue(float value)
    {
        if(value <= 0.0f)
        {
            value = 0.0f;
        }

        if(value >= slider.maxValue)
        {
            value = slider.maxValue;
        }

        if(slider.value != value){
            slider.value = value;
        }
    }

    private bool isValidValue(float value){
        bool ret = false;

        if(value >= slider.minValue && value <= slider.maxValue)
        {
            ret = true;
        }

        return ret;
    }

}
