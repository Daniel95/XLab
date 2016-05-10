using UnityEngine;
using System.Collections;

public class ConnectionEffect : MonoBehaviour {

    [SerializeField]
    private Transform myInfoVisual;

    public void StartEffect(Vector2 _otherOccupier) {
        myInfoVisual.GetComponent<IgnoreNonParentCollision>().SetKinematic(false);

        myInfoVisual.GetComponent<RandomDirectionPush>().Executing = false;

        myInfoVisual.GetComponent<ControlledBounce>().ControlBounce = false;

        WaypointsController waypointsController = myInfoVisual.GetComponent<WaypointsController>();

        waypointsController.AddWaypoint(_otherOccupier);
        waypointsController.AddWaypoint(transform.position);
        waypointsController.StartPatrolling();
    }
}
