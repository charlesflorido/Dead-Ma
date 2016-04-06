using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour
{

    public float seconds;
    public Text time;
    public bool play;
    public Text zombieCount;

    // Use this for initialization
    void Start()
    {
        seconds = 0;
        play = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            seconds += Time.deltaTime * 1;
            UpdateText();
        }
    }

    public void UpdateText()
    {
        int secondSign = (int)seconds % 60;
        int minuteSign = (int)seconds / 60;

        string text = ((minuteSign >= 10) ? "" : "0") + minuteSign + ":" + ((secondSign >= 10) ? "" : "0") + secondSign;
        time.text = text;
    }

    public void SetZombieCount(int n)
    {
        zombieCount.text = n + " Zombies";
    }
}
