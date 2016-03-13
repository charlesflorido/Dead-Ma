using System;
using UnityEngine;

public class PlayerController : BaseClass {


    public Weapon[] weapons;
    private int currentWeapon;
    private int previousWeapon;

    public float moveSpeed = 2.0f;

    public PlayerSpriteController sprite;

	void Start () {
        currentWeapon = 0;
        previousWeapon = 0;
        weapons[0].gameObject.SetActive(true);
	}
	

    public override void Run()
    {
        UpdateMouseLook();
        UpdateMovement();
        UpdateWeapon();
    }

    void UpdateMouseLook()
    {
        Vector3 pos = Input.mousePosition;

        
        pos = Camera.main.ScreenToWorldPoint(pos);
        
        Vector3 dir = this.transform.position - pos;
        float angle = 0.0f;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += 90.0f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void UpdateMovement()
    {
        sprite.GetComponent<Animator>().SetBool("stand", true);

        if (Input.GetAxisRaw("Horizontal") > 0.05f || Input.GetAxisRaw("Horizontal") < -0.05f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            sprite.GetComponent<Animator>().SetBool("stand", false);
        }


        if (Input.GetAxisRaw("Vertical") > 0.05f || Input.GetAxisRaw("Vertical") < -0.05f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            sprite.GetComponent<Animator>().SetBool("stand", false);
        }
        else if (Input.GetMouseButton(1))
        {
            transform.Translate(new Vector3(0f, 1 * moveSpeed * Time.deltaTime, 0f));
            sprite.GetComponent<Animator>().SetBool("stand", false);
        }


    }

    void UpdateWeapon()
    {
        UpdateChangeWeapon();
        UpdateCurrentWeapon();
    }

    void UpdateChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(currentWeapon != 0)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_PISTOL);
                setCurrentWeapon(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(currentWeapon != 1)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
                setCurrentWeapon(1);
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //sprite.setPlayerHand(PlayerHandTypes.CARRYING_GRENADE);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currentWeapon != previousWeapon)
            {
                if(previousWeapon == 0)
                {
                    sprite.setPlayerHand(PlayerHandTypes.CARRYING_PISTOL);
                }
                else if(previousWeapon == 1)
                {
                    sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
                }


                setCurrentWeapon(previousWeapon);
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            int n = (currentWeapon + 1) % 2;

            if (n == 0)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_PISTOL);
            }
            else if (previousWeapon == 1)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
            }

            setCurrentWeapon(n);
        }

    }

    void setCurrentWeapon(int n)
    {

        if (n >= 0 && n < weapons.Length) 
        {
            weapons[currentWeapon].gameObject.SetActive(false);
            weapons[n].gameObject.SetActive(true);
            weapons[n].Load();
            previousWeapon = currentWeapon;
            currentWeapon = n;
        }
    }

    void UpdateCurrentWeapon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapons[currentWeapon].Fire();
         
        }

        if (Input.GetMouseButton(0))
        {
            weapons[currentWeapon].FireOn();
        }

        if (Input.GetMouseButtonUp(0))
        {
            weapons[currentWeapon].FireEnd();
        }
    }

    
}
