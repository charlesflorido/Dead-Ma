using UnityEngine;
using System.Collections;

public class TacticalIntroLogo : MonoBehaviour {

    public int mainMenu;

    void LoadMainMenu()
    {
        Application.LoadLevel(mainMenu);
    }
    
}
