using UnityEngine;
using System.Collections;

public class GrenadeLauncherSight : MonoBehaviour {

    public float moveSpeed;
    public Vector2 upperLimit;
    public Vector2 lowerLimit;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        UpdateLimits();

        if(Input.GetAxis("Mouse ScrollWheel") != 0.0f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxis("Mouse ScrollWheel") * moveSpeed * Time.deltaTime, 0f));
        }
        else
        {
            float speed = moveSpeed / 10;

            if (Input.GetKey(KeyCode.Z))
            {
                transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));
            }

            if (Input.GetKey(KeyCode.X))
            {
                transform.Translate(new Vector3(0f, -speed * Time.deltaTime, 0f));
            }
        }

	}

    void UpdateLimits()
    {
        if(transform.localPosition.y > upperLimit.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, upperLimit.y, transform.localPosition.z);
        }

        if (transform.localPosition.y < lowerLimit.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, lowerLimit.y, transform.localPosition.z);
        }
    }
}
