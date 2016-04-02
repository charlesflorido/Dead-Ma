using UnityEngine;
using System.Collections;

public class MuzzleFlashController : MonoBehaviour {

    public Bullet bullet;
    public bool hasFiniteAmmo = true;

    private Animator anim;
    private int Ammo = 0;


    public AudioClip audioBlast;
    public AudioClip audioEmpty;
    public float Accuracy = 10;
    private float actualAccuracy = 0;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        actualAccuracy = Accuracy;
	}

	
	public void fire(bool shouldFire)
    {
        if (hasFiniteAmmo)
        {
            if(Ammo > 0)
            {
                anim.SetBool("start", shouldFire);
            }
            else
            {
                AudioSource.PlayClipAtPoint(audioEmpty, this.transform.position);
                stopFire();
            }
        }
        else
        {

            try
            {
                anim.SetBool("start", shouldFire);
            }
            catch(System.NullReferenceException)
            {
                GetComponent<Animator>().SetBool("start", shouldFire);
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
        if (bullet) 
        {
            if (hasFiniteAmmo)
            {
                if(Ammo > 0)
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
                LaunchBullet();
            }
            
        }
        else
        {

        }

    }

    private void LaunchBullet()
    {
        float inAccuracy = (Random.Range(100 - Accuracy - actualAccuracy, 100 + Accuracy + actualAccuracy) / 100);
        Vector3 pos = Input.mousePosition;

        //pos = new Vector3(pos.x * inAccuracy, pos.y * inAccuracy, pos.z);

        pos = Camera.main.ScreenToWorldPoint(pos);


        Vector3 dir = this.transform.position - pos;
        float angle = 0.0f;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += (90.0f * inAccuracy);


        Bullet fire_bullet = Instantiate(bullet, transform.position, Quaternion.identity) as Bullet;
        fire_bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float speedX = Mathf.Cos(Mathf.Deg2Rad * (angle - 90)) * -1;
        float speedY = Mathf.Sin(Mathf.Deg2Rad * (angle - 90)) * -1;

        

        fire_bullet.setVelocity(new Vector2(speedX, speedY));


        AudioSource.PlayClipAtPoint(audioBlast, this.transform.position);
    }

    public void AddAmmo(int x)
    {
        if(x > 0)
        {
            Ammo += x;
        }
    }

    public int GetAmmo()
    {
        return Ammo;
    }


    public void SetAdditionalInAccuracy(int n)
    {
        actualAccuracy = n;
    }
    
}
