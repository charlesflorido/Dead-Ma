using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseClass {


    public Weapon[] weapons;
    private int currentWeapon;
    private int previousWeapon;

    public float moveSpeed = 2.0f;

    public PlayerSpriteController sprite;
    public Text ammoText;

    private bool isMoving;

	void Start () {
        currentWeapon = 0;
        previousWeapon = 0;
        weapons[0].gameObject.SetActive(true);
        ammoText.text = weapons[currentWeapon].GetAmmoLeft();
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
        isMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.05f || Input.GetAxisRaw("Horizontal") < -0.05f)
        {

            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * (moveSpeed - weapons[currentWeapon].Weight) * Time.deltaTime, 0f, 0f));
            sprite.GetComponent<Animator>().SetBool("stand", false);
            isMoving = true;
        }


        if (Input.GetAxisRaw("Vertical") > 0.05f || Input.GetAxisRaw("Vertical") < -0.05f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * (moveSpeed - weapons[currentWeapon].Weight) * Time.deltaTime, 0f));
            sprite.GetComponent<Animator>().SetBool("stand", false);
            isMoving = true;

        }
        else if (Input.GetMouseButton(1))
        {
            transform.Translate(new Vector3(0f, 1 * (moveSpeed - weapons[currentWeapon].Weight) * Time.deltaTime, 0f));
            sprite.GetComponent<Animator>().SetBool("stand", false);
            isMoving = true;
        }


        if(isMoving)
        {
            weapons[currentWeapon].SetInaccuracy(10);
        }
        else
        {
            weapons[currentWeapon].SetInaccuracy(0);
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
            if(currentWeapon != 0 && weapons.Length >= 1)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_PISTOL);
                setCurrentWeapon(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(currentWeapon != 1 && weapons.Length >= 2)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
                setCurrentWeapon(1);
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentWeapon != 2 && weapons.Length >= 3)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
                setCurrentWeapon(2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (currentWeapon != 3 && weapons.Length >= 4)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
                setCurrentWeapon(3);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (currentWeapon != 4 && weapons.Length >= 5)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_PISTOL);
                setCurrentWeapon(4);
            }
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
                else if(previousWeapon == 2)
                {
                    sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
                }
                else if (previousWeapon == 3)
                {
                    sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
                }
                else if (previousWeapon == 4)
                {
                    sprite.setPlayerHand(PlayerHandTypes.CARRYING_PISTOL);
                }

                setCurrentWeapon(previousWeapon);
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            int n = (currentWeapon + 1) % (weapons.Length);

            if (n == 0)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_PISTOL);
            }
            else if (previousWeapon == 1)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
            }
            else if (previousWeapon == 2)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
            }
            else if (previousWeapon == 3)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_RIFLE);
            }
            else if (previousWeapon == 4)
            {
                sprite.setPlayerHand(PlayerHandTypes.CARRYING_PISTOL);
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
            ammoText.text = weapons[currentWeapon].GetAmmoLeft();
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

        ammoText.text = weapons[currentWeapon].GetAmmoLeft();
    }

    
}
