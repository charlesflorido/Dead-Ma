using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(Zombie))]
public class EnemyAI : MonoBehaviour {

    public Transform target;
    
    //How many times each second we will update our path
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    //The calculated path
    public Path path;

    public float speed;
    public float rotationSpeed = 2.0f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    // The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWayPointDistance = 3.0f;

    private int currentWayPoint = 0;

    //Patrol Variables
    private bool patrolling;

    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;

    //Player Detection
    public EnemyTrigger enemyTrigger;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        //Start a new path to the target position, return the result to the OnPathComplete method
        InitializePatrolling();
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        StartCoroutine(UpdatePath());

    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            yield return null;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f/updateRate);
        StartCoroutine(UpdatePath());
    }

    void FixedUpdate()
    {
      
        if (enemyTrigger.Triggered)
        {
            FollowTarget();
        }
        else
        {
            Patrol();
        }
    }

    public void Patrol()
    {
        if (patrolling)
        {
            timeToMoveCounter -= Time.deltaTime;
            rb.velocity = moveDirection;

            UpdateDirection(moveDirection);

            if(timeToMoveCounter < 0f)
            {
                patrolling = false;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;

            patrolling = true;
            timeToMoveCounter = timeToMove;
                
            moveDirection = new Vector3(Random.Range(-1f, 1f) * (speed * 0.02f), Random.Range(-1f, 1f) * (speed * 0.02f), 0f);    
        }

    }

    public void InitializePatrolling()
    {
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }

    public void FollowTarget()
    {
        if (target == null)
        {
            return;
        }

        if (path == null)
        {
            return;
        }

        if (currentWayPoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to the next waypoint
        Vector3 dir = path.vectorPath[currentWayPoint] - transform.position;
        dir *= Time.fixedDeltaTime * (speed * 1.5f);

        //AI movement
        UpdateDirection(dir);
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);

        if (dist < nextWayPointDistance)
        {

            currentWayPoint++;
            return;
        }

    }

    public void UpdateDirection(Vector3 dir)
    {
        dir.z = 0.0f;
        if (dir != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                   Quaternion.FromToRotation(Vector3.down, dir),
                                                   rotationSpeed * Time.deltaTime);
    }


}
