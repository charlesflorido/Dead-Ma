using UnityEngine;
using System.Collections;

public class EnemyLifeSpan : MonoBehaviour {

	public int hitPoints;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D target) {
		if(target.gameObject.tag == "projectile") {
			hitPoints--;
		}
		
		if (hitPoints == 0) {
			GameObject.Destroy(gameObject);
		}
	}
}
