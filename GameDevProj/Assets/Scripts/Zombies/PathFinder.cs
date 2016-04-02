using UnityEngine;
using System.Collections;

public class PathFinder : MonoBehaviour {

    public Transform target;
    public float moveSpeed;
    public int rotationSpeed;

    void Start()
    {

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


        dir.z = 0.0f;
        if (dir != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                   Quaternion.FromToRotation(Vector3.right, dir),
                                                   rotationSpeed * Time.deltaTime);
        //Move Towards Target
        transform.position += (target.position - transform.position).normalized
            * moveSpeed * Time.deltaTime;
    }


}
