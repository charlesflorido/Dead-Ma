using UnityEngine;
using System.Collections;

public class MuzzleFlashController : MonoBehaviour {

    public Bullet bullet;
    private Animator anim;

    public AudioClip audioBlast;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

	
	public void fire(bool shouldFire)
    {
        anim.SetBool("start", shouldFire);
    }

    void stopFire()
    {
        anim.SetBool("start", false);
    }

    void Shoot()
    {
        if (bullet)
        {

            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);


            Vector3 dir = this.transform.position - pos;
            float angle = 0.0f;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle += 90.0f;
        

            Bullet fire_bullet = Instantiate(bullet, transform.position, Quaternion.identity) as Bullet;
            fire_bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            float speedX = Mathf.Cos(Mathf.Deg2Rad * (angle - 90)) * -1;
            float speedY = Mathf.Sin(Mathf.Deg2Rad * (angle - 90)) * -1;

            fire_bullet.setVelocity(new Vector2(speedX, speedY));


            AudioSource.PlayClipAtPoint(audioBlast, this.transform.position);
        }

    }

    
}
