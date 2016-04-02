using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

    public Rocket rocket;
    public AudioClip audioBlast;
    public AudioClip audioEmpty;

    private Animator anim;
    private int Ammo = 0;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	

    public void fire(bool shouldFire)
    {
        if (GetComponent<Animator>().GetBool("start") == false)
        {
            if (Ammo > 0)
            {
                try
                {
                    anim.SetBool("start", shouldFire);
                }
                catch (System.NullReferenceException)
                {
                    GetComponent<Animator>().SetBool("start", shouldFire);
                }
            }
            else
            {
                AudioSource.PlayClipAtPoint(audioEmpty, this.transform.position);
                stopFire();
            }
        }
    

    }

    void stopFire()
    {
        try
        {
            anim.SetBool("start", false);
        }
        catch (System.NullReferenceException)
        {
            GetComponent<Animator>().SetBool("start", false);
        }

    }

    void Shoot()
    {
        if (rocket)
        {
            if (Ammo > 0)
            {
                LaunchBullet();
                Ammo--;
            }
            else
            {
                AudioSource.PlayClipAtPoint(audioEmpty, this.transform.position);
                stopFire();
            }
        }
        else
        {

        }

    }

    private void LaunchBullet()
    {
        Vector3 pos = Input.mousePosition;

        pos = Camera.main.ScreenToWorldPoint(pos);

        Vector3 dir = this.transform.position - pos;
        float angle = 0.0f;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += (90.0f);


        Rocket fire_bullet = Instantiate(rocket, transform.position, Quaternion.identity) as Rocket;
        fire_bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float speedX = Mathf.Cos(Mathf.Deg2Rad * (angle - 90)) * -1;
        float speedY = Mathf.Sin(Mathf.Deg2Rad * (angle - 90)) * -1;

        fire_bullet.setVelocity(new Vector2(speedX, speedY));

        AudioSource.PlayClipAtPoint(audioBlast, this.transform.position);
    }

    public void AddAmmo(int x)
    {
        if (x > 0)
        {
            Ammo += x;
        }
    }

    public int GetAmmo()
    {
        return Ammo;
    }
}
