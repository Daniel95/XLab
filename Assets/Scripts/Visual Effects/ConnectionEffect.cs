using UnityEngine;
using System.Collections.Generic;

public class ConnectionEffect : MonoBehaviour {

    //delegate type
    public delegate void FinishConnectionMethod();

    //delegate instance
    public FinishConnectionMethod ConnectionIsFinished;

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameObject myHead;

    [SerializeField]
    private GameObject pointVisual;

    [SerializeField]
    private bool isStudent;

    [SerializeField]
    private float symbolSize = 0.175f;

    private WaypointsController waypointsController;

    private IgnoreCollisions ignoreCollisionsBall;

    private bool connectionActive;

    public void StartEffect(Transform _otherOccupier)
    {
        waypointsController = ball.GetComponent<WaypointsController>();

        ignoreCollisionsBall = ball.GetComponent<IgnoreCollisions>();
        ConnectionEffect otherConnectionEffect = _otherOccupier.GetComponent<ConnectionEffect>();

        connectionActive = true;

        if(!otherConnectionEffect.connectionActive)
            otherConnectionEffect.StartEffect(transform);

        ignoreCollisionsBall.AddActiveCollision(otherConnectionEffect.Ball.GetComponent<Collider>());
        ignoreCollisionsBall.RemoveActiveCollision(myHead.GetComponent<Collider>());

        ball.GetComponent<RandomDirectionPush>().Executing = false;

        ball.GetComponent<ControlledBounce>().ControlBounce = false;

        //only spawn the waypoints if i am a student
        if (isStudent)
            SpawnWayPoints(_otherOccupier);
    }

    void SpawnWayPoints(Transform _otherOccupier)
    {
        Vector2 vectorToTarget = transform.position - _otherOccupier.position;

        float totalDistance = Vector3.Distance(transform.position, _otherOccupier.position);

        float editedDistance = totalDistance * symbolSize;

        List<Vector2> waypointPosition = new List<Vector2>();

        WaypointsController otherWaypointsController = _otherOccupier.GetComponentInChildren<WaypointsController>();

        //add points:

        //point 1
        waypointPosition.Add(transform.position);

        //point 2
        waypointPosition.Add(transform.position + (transform.up + transform.right) * editedDistance);

        //point 3
        waypointPosition.Add((Vector2)transform.position - vectorToTarget / 2);

        //point 4
        waypointPosition.Add(_otherOccupier.position + (_otherOccupier.right + _otherOccupier.up) * editedDistance);

        //point 5
        waypointPosition.Add(_otherOccupier.position);

        //point 6
        waypointPosition.Add(_otherOccupier.position + (_otherOccupier.right + -_otherOccupier.up) * editedDistance);

        //point 7
        waypointPosition.Add((Vector2)transform.position - vectorToTarget / 2);

        //point 8
        waypointPosition.Add(transform.position + (transform.right + -transform.up) * editedDistance); 

        for (int i = 0; i < waypointPosition.Count; i++) {
            waypointsController.AddWaypoint(waypointPosition[i]);
            otherWaypointsController.AddWaypoint(waypointPosition[i]);
        }

        otherWaypointsController.WaypointIndex = 4;
        otherWaypointsController.SetBackwards(true);
        otherWaypointsController.StartPatrolling();
        waypointsController.StartPatrolling();
    }

    public void FinishConnection() {
        if (connectionActive)
        {
            waypointsController.GoToStartpoint();
            waypointsController.FinishedReturning += WaitingForFinishReturn;
        }
        else if (ConnectionIsFinished != null)
        {
            Destroy(ball);
            ConnectionIsFinished();
        }
    }

    void WaitingForFinishReturn()
    {
        waypointsController.FinishedReturning -= WaitingForFinishReturn;

        Destroy(ball);

        ignoreCollisionsBall.AddActiveCollision(myHead.GetComponent<Collider>());

        if (ConnectionIsFinished != null)
            ConnectionIsFinished();
    }

    public GameObject Ball {
        get { return ball; }
    }

    public bool ConnectionActive {
        set { connectionActive = value; }
        get { return connectionActive; }
    }
}
