using UnityEngine;

public class PlayerSpriteController : MonoBehaviour {

    public AudioClip soundWalk;
    public PlayerController player;

    public Sprite spritePistol;
    public Sprite spriteRifle;
    public Sprite spriteGrenade;

    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	void Walk()
    {
        AudioSource.PlayClipAtPoint(soundWalk, player.transform.position);
    }

    public void setPlayerHand(PlayerHandTypes handType)
    {
        if(handType == PlayerHandTypes.CARRYING_PISTOL)
        {
            sprite.sprite = spritePistol;
        }
        else if(handType == PlayerHandTypes.CARRYING_RIFLE)
        {
            sprite.sprite = spriteRifle;
        }
        else if(handType == PlayerHandTypes.CARRYING_GRENADE)
        {
            sprite.sprite = spriteGrenade;
        }
    }
}
