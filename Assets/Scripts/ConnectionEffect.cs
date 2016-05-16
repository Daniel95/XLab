using UnityEngine;
using System.Collections;

public class ConnectionEffect : MonoBehaviour {

    [SerializeField]
    private Transform myInfoVisual;

    [SerializeField]
    private Transform myHead;

    public void StartEffect(Transform _otherOccupier) {

        IgnoreCollisions ignoreCollisions = myInfoVisual.GetComponent<IgnoreCollisions>();
        ignoreCollisions.AddActiveCollision(_otherOccupier.GetComponent<ConnectionEffect>().MyInfoVisual);
        ignoreCollisions.RemoveActiveCollision(myHead);

        myInfoVisual.GetComponent<RandomDirectionPush>().Executing = false;

        myInfoVisual.GetComponent<ControlledBounce>().ControlBounce = false;

        WaypointsController waypointsController = myInfoVisual.GetComponent<WaypointsController>();



        waypointsController.AddWaypoint(_otherOccupier.position);
        waypointsController.AddWaypoint(transform.position);



        waypointsController.StartPatrolling();
    }

    public Transform MyInfoVisual {
        get { return myInfoVisual; }
    }
}
