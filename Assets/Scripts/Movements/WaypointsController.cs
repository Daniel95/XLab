using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointsController : MonoBehaviour
{
    //delegate type
    public delegate void DoneReturningToOwnerMethod();

    //delegate instance
    public DoneReturningToOwnerMethod FinishedReturning;

    private List<Vector2> waypoints = new List<Vector2>();

    private int waypointIndex;

    private GoToPointSmooth goToPointSmooth;

    private Vector2 localStartPos;

    private int increment = 1;

    private int startWaypoint;

    void Awake()
    {
        goToPointSmooth = GetComponent<GoToPointSmooth>();
        localStartPos = transform.localPosition;
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
        if (FinishedReturning != null)
            FinishedReturning();

        waypointIndex += increment;

       if (waypointIndex >= waypoints.Count)
            waypointIndex = 0;
       else if(waypointIndex < 0)
            waypointIndex = waypoints.Count - 1;

        goToPointSmooth.Point = waypoints[waypointIndex];
        goToPointSmooth.StartSeeking();
    }

    public void StartPatrolling() {
        transform.localPosition = localStartPos;

        startWaypoint = waypointIndex;
        goToPointSmooth.Point = waypoints[waypointIndex];
        goToPointSmooth.StartSeeking();
    }

    public void StopPatrolling() {
        goToPointSmooth.StopSeeking();
    }

    public void AddWaypoint(Vector2 _newWaypoint) {
        waypoints.Add(_newWaypoint);
    }

    public void SetBackwards(bool _backwards)
    {
        if (_backwards)
            increment = -1;
        else
            increment = 1;
    }

    public int WaypointIndex
    {
        set { waypointIndex = value; }
    }

    public void GoToStartpoint() {
        waypointIndex = startWaypoint;
        goToPointSmooth.Point = waypoints[waypointIndex];
    }
}
