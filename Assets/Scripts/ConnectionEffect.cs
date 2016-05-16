using UnityEngine;
using System.Collections.Generic;

public class ConnectionEffect : MonoBehaviour {

    [SerializeField]
    private Transform myInfoVisual;

    [SerializeField]
    private Transform myHead;

    [SerializeField]
    private GameObject pointVisual;

    [SerializeField]
    private bool isStudent;

    public void StartEffect(Transform _otherOccupier)
    {
        //IgnoreCollisions ignoreCollisions = myInfoVisual.GetComponent<IgnoreCollisions>();
        ConnectionEffect otherConnectionEffect = GetComponent<ConnectionEffect>();

        //ignoreCollisions.AddActiveCollision(otherConnectionEffect.MyInfoVisual);
        //ignoreCollisions.RemoveActiveCollision(myHead);

        myInfoVisual.GetComponent<RandomDirectionPush>().Executing = false;

        myInfoVisual.GetComponent<ControlledBounce>().ControlBounce = false;

        //only spawn the waypoints the other has not spawned them first
        if (isStudent)
            SpawnWayPoints(_otherOccupier);
    }

    void SpawnWayPoints(Transform _otherOccupier)
    {
        WaypointsController waypointsController = myInfoVisual.GetComponent<WaypointsController>();

        Vector2 vectorToTarget = transform.position - _otherOccupier.position;

        float totalDistance = Vector3.Distance(transform.position, _otherOccupier.position);

        float editedDistance = totalDistance * 0.25f;

        List<Vector2> waypointPosition = new List<Vector2>();

        WaypointsController otherWaypointsController = _otherOccupier.GetComponentInChildren<WaypointsController>();

        //add points:

        //point 1
        waypointPosition.Add(transform.position);
        //Instantiate(pointVisual, transform.position, transform.rotation);

        //point 2
        waypointPosition.Add(transform.position + (transform.up + transform.right) * editedDistance);
        //Instantiate(pointVisual, transform.position + (transform.up + transform.right) * editedDistance, transform.rotation);

        //point 3
        waypointPosition.Add((Vector2)transform.position - vectorToTarget / 2);
        //Instantiate(pointVisual, (Vector2)transform.position - vectorToTarget / 2, transform.rotation);

        //point 4
        waypointPosition.Add(_otherOccupier.position + (_otherOccupier.right + _otherOccupier.up) * editedDistance);
        //Instantiate(pointVisual, _otherOccupier.position + (_otherOccupier.right + -_otherOccupier.up) * editedDistance, _otherOccupier.rotation);

        //point 5
        waypointPosition.Add(_otherOccupier.position);
        //Instantiate(pointVisual, _otherOccupier.position, _otherOccupier.rotation);

        //point 6
        waypointPosition.Add(_otherOccupier.position + (_otherOccupier.right + -_otherOccupier.up) * editedDistance);
        //Instantiate(pointVisual, _otherOccupier.position + (_otherOccupier.right + _otherOccupier.up) * editedDistance, _otherOccupier.rotation);

        //point 7
        waypointPosition.Add((Vector2)transform.position - vectorToTarget / 2);
        //Instantiate(pointVisual, (Vector2)transform.position - vectorToTarget / 2, transform.rotation);

        //point 8
        waypointPosition.Add(transform.position + (transform.right + -transform.up) * editedDistance);
        //Instantiate(pointVisual, transform.position + (transform.right + -transform.up) * editedDistance, transform.rotation);   

        for (int i = 0; i < waypointPosition.Count; i++) {
            waypointsController.AddWaypoint(waypointPosition[i]);
            otherWaypointsController.AddWaypoint(waypointPosition[i]);
        }

        otherWaypointsController.WaypointIndex = 4;
        otherWaypointsController.SetBackwards(true);
        otherWaypointsController.StartPatrolling();
        waypointsController.StartPatrolling();
    }

    public Transform MyInfoVisual {
        get { return myInfoVisual; }
    }
}
