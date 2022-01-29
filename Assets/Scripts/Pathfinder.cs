using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        // If not at last waypoint
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            //  distance we are moving each frame
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;

            // Vector2.MoveTowards(currentPos, targetPos, delta):
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            // If on waypoint -> increment waypointIndex -> targetPosition will become position of next waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        // If at last waypoint
        else 
        {
            Destroy(gameObject);
        }
    }
}
