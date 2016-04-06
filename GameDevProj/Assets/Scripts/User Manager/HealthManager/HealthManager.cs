using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public Text healthText;
    public Slider healthSlider;

    public void UpdateHealthManager(float x)
    {
        if(x <= 0.0f) { x = 0.0f; }
        if(x >= 500.0f) { x = 500.0f; }

        healthText.text = x + "";
        healthSlider.value = x;

        if(x <= 0)
        {
            UserManager.instance.Killed();
        }
    }
}
