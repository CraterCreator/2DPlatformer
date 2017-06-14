using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Player))]
public class AIControl : MonoBehaviour
{

    public Transform[] waypoints;
    public bool crouch = false;
    public bool jump = false;
    public float stoppingDistance = 5f;
    public float move = 0;

    private Player character;
    private int currentPoint = 0;
    private float distance = 0;

    void Start()
    {
        character = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        //Makes the enemy move back and forth between waypoints
        float playerXPos = transform.position.x;
        float waypointXPos = GetWaypointPos().x;
        float move = 0;
        if (playerXPos > waypointXPos)
            move = -1;
        else
            move = 1;
        character.Move(move, crouch, jump);
        jump = false;
    }

    Vector3 GetWaypointPos()
    {
        // Get Distance from position to way point
        Vector3 waypointPos = waypoints[currentPoint].position;
        distance = Vector3.Distance(transform.position, waypointPos);
        // Check if im close to stopping distance
        if (distance <= stoppingDistance)
        {
            // Go to the next waypoint
            currentPoint++;
        }
        // Check if current point is outside waypoint length
        if (currentPoint >= waypoints.Length)
        {
            // Reset currentPoint
            currentPoint = 0;
        }
        // Return the waypoint
        return waypoints[currentPoint].position;
    }
}
