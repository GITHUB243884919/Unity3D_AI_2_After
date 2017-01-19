using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
public class AStarAI : MonoBehaviour 
{
    public GameObject target;
    private Vector3 targetPosition;
    private Seeker seeker;
    private CharacterController controller;
    public Path path;
    public float speed = 100;
    public float turnSpeed = 0.2f;
    public float nextWaypointDistance = 3;
    private int currentWaypoint = 0;

	// Use this for initialization
	void Start () 
    {
        seeker = GetComponent<Seeker>();
        //controller = GetComponent<CharacterController>();
        seeker.pathCallback += OnPathComplete;
        targetPosition = target.transform.position;
        seeker.StartPath(transform.position, targetPosition);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void FixedUpdate()
    {
        if (path == null)
        {
            Debug.Log("Path == null");
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("End of Path Reached!");
            return;
        }

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;
        //controller.SimpleMove(dir);
        transform.position += dir;

        Quaternion targetRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
            Time.deltaTime * turnSpeed);

        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) <
            nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

    }

    void OnPathComplete(Path p)
    {
        Debug.Log("Find the path " + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }

    void OnDisable()
    {
        seeker.pathCallback -= OnPathComplete;
    }
}
