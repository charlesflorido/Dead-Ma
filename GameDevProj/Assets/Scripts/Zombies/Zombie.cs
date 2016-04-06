using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public abstract class Zombie : MonoBehaviour {

    public float life;
    public ZombieHealth zombieHealth;
    public RandomSounds walkingSounds;
    public RandomSounds painSounds;
    public RandomSounds deathSounds;

    public abstract void Attack();
    public abstract void Walk();
    public abstract void Death();
    public abstract void TakeDamage(float x);

    public void ShowHealth(bool show)
    {
        zombieHealth.ShowHealth(show);
    }

    [MethodImpl(MethodImplOptions.Synchronized)] 
    public void ReduceHealth(float x)
    {
        life -= x;
        painSounds.PlayRandomClip(this.transform);
    }

    void PlayWalkingSound()
    {
        walkingSounds.PlayLinearClip(this.transform);
    }
}
