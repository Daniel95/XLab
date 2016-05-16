using UnityEngine;
using System.Collections;

public class ConnectionEffect : MonoBehaviour {

    [SerializeField]
    private Transform myInfoVisual;

    [SerializeField]
    private Transform myHead;

    [SerializeField]
    private GameObject pointVisual;

    public void StartEffect(Transform _otherOccupier)
    {
        IgnoreCollisions ignoreCollisions = myInfoVisual.GetComponent<IgnoreCollisions>();
        ignoreCollisions.AddActiveCollision(_otherOccupier.GetComponent<ConnectionEffect>().MyInfoVisual);
        ignoreCollisions.RemoveActiveCollision(myHead);

        myInfoVisual.GetComponent<RandomDirectionPush>().Executing = false;

        myInfoVisual.GetComponent<ControlledBounce>().ControlBounce = false;

        SpawnWayPoints(_otherOccupier.position);
    }

    void SpawnWayPoints(Vector2 _otherOccupierPosition)
    {
        WaypointsController waypointsController = myInfoVisual.GetComponent<WaypointsController>();

        Vector2 vectorToTarget = (Vector2)transform.position - _otherOccupierPosition;

        //add points:
        waypointsController.AddWaypoint(transform.position);

        //Instantiate(pointVisual, new Vector2())

        //waypointsController.AddWaypoint();





        waypointsController.AddWaypoint(_otherOccupierPosition);
        

        waypointsController.StartPatrolling();
    }

    public Transform MyInfoVisual {
        get { return myInfoVisual; }
    }
}
