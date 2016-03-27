using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour 
{
	public Transform target;
	public float moveSpeed;
	public int rotationSpeed;
	public AudioClip sound;
	private int lifeline;

	void Start()
	{
		lifeline = 3;
	}


	
	void Update() 
	{

			GameObject go = GameObject.FindWithTag("Player");

			if (go != null)
			{
				target = go.transform;
			}

			if (target == null)
			{
				return;
			}

			Vector3 dir = target.position - transform.position;


			// Only needed if objects don't share 'z' value.
			dir.z = 0.0f;
			if (dir != Vector3.zero) 
				transform.rotation = Quaternion.Slerp ( transform.rotation, 
				                                       Quaternion.FromToRotation (Vector3.right, dir), 
				                                       rotationSpeed * Time.deltaTime);
			//Move Towards Target
			transform.position += (target.position - transform.position).normalized 
				* moveSpeed * Time.deltaTime;
	}
	

	void OnCollisionEnter2D(Collision2D target)
	{
		if(target.gameObject.tag == "projectile")
		{
			AudioSource.PlayClipAtPoint(sound, this.gameObject.transform.position);
			lifeline--;
			if (lifeline == 0)
				Destroy(gameObject);
		}
	}
}