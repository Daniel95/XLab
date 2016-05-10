using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointsController : MonoBehaviour
{
    private List<Vector2> waypoints = new List<Vector2>();

    private int waypointIndex;

    private GoToPointSmooth goToPointSmooth;

    private Vector2 localStartPos;

    void Awake()
    {
        goToPointSmooth = GetComponent<GoToPointSmooth>();
        transform.localPosition = localStartPos;
    }

    void OnEnable()
    {
        goToPointSmooth.ReachedPoint += NextPoint;
    }

    void OnDisable()
    {
        goToPointSmooth.ReachedPoint -= NextPoint;
    }

    //set the next, or first waypoint in the array as target in followpointsmooth.
    private void NextPoint()
    {
        if (waypointIndex < waypoints.Count - 1)
            waypointIndex++;
        else
            waypointIndex = 0;

        goToPointSmooth.Point = waypoints[waypointIndex];
        goToPointSmooth.StartSeeking();
    }

    public void StartPatrolling() {
        transform.localPosition = localStartPos;

        goToPointSmooth.Point = waypoints[waypointIndex];
        goToPointSmooth.StartSeeking();
    }

    public void StopPatrolling() {
        goToPointSmooth.StopSeeking();
    }

    public void AddWaypoint(Vector2 _newWaypoint) {
        waypoints.Add(_newWaypoint);
    }
}
