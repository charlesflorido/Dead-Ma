using UnityEngine;
using System.Collections;

public class UserManager : MonoBehaviour {

    public static UserManager instance;

    public int currentLevel;

    public TimeManager timeManager;
    public HealthManager healthManager;
    public AmmoManager ammoManager;
    public LoadLevel loadLevel;
    public RandomSounds deathSounds;

    public int Zombies;
    public bool GameSet = false;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void AddZombie()
    {
        Zombies++;
        timeManager.SetZombieCount(Zombies);
        GameSet = true;
    }

    public void RemoveZombie()
    {
        Zombies--;
        timeManager.SetZombieCount(Zombies);

        if(Zombies <= 0)
        {
            GameGlobals.Finished = (int)timeManager.seconds;
            loadLevel.ChangeScene(currentLevel + 15);
        }
    }

    public void CommitSuicide()
    {
        loadLevel.ChangeScene(14);
    }

    public void Killed()
    {
        loadLevel.ChangeScene(13);
        deathSounds.PlayRandomClip(gameObject.transform);
    }
  
}
