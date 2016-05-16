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

        SpawnWayPoints(_otherOccupier);
    }

    void SpawnWayPoints(Transform _otherOccupier)
    {
        WaypointsController waypointsController = myInfoVisual.GetComponent<WaypointsController>();

        Vector2 vectorToTarget = transform.position - _otherOccupier.position;

        print(vectorToTarget);


        float totalDistance = Vector3.Distance(transform.position, _otherOccupier.position);

        //float editedDistance = totalDistance * 0.25f;

        float editedDistance = 5;

        //add points:
        /*
        //point 1
        //waypointsController.AddWaypoint(transform.position);
        Instantiate(pointVisual, transform.position, transform.rotation);

        //point 2
        //waypointsController.AddWaypoint(transform.position + transform.right * editedDistance + transform.forward * editedDistance);
        Instantiate(pointVisual, transform.position + transform.right * editedDistance + transform.up * editedDistance, transform.rotation);

        //point 3
        //waypointsController.AddWaypoint((Vector2)transform.position + vectorToTarget / 2);
        Instantiate(pointVisual, (Vector2)transform.position + vectorToTarget / 2, transform.rotation);

        //point 4
        //waypointsController.AddWaypoint(_otherOccupier.position + -_otherOccupier.right * editedDistance + _otherOccupier.forward * editedDistance);
        Instantiate(pointVisual, _otherOccupier.position + -_otherOccupier.right * editedDistance + _otherOccupier.up * editedDistance, _otherOccupier.rotation);

        //point 5
        //waypointsController.AddWaypoint(_otherOccupier.position);
        Instantiate(pointVisual, _otherOccupier.position, _otherOccupier.rotation);

        //point 6
        //waypointsController.AddWaypoint(_otherOccupier.position + _otherOccupier.right * editedDistance + _otherOccupier.forward * editedDistance);
        Instantiate(pointVisual, _otherOccupier.position + _otherOccupier.right * editedDistance + _otherOccupier.up * editedDistance, _otherOccupier.rotation);

        //point 7
        //waypointsController.AddWaypoint((Vector2)transform.position + vectorToTarget / 2);
        Instantiate(pointVisual, (Vector2)transform.position + vectorToTarget / 2, transform.rotation);

        //point 8
        //waypointsController.AddWaypoint(transform.position + -transform.right * editedDistance + transform.forward * editedDistance);
        Instantiate(pointVisual, transform.position + -transform.right * editedDistance + transform.up * editedDistance, transform.rotation);   
        
        */
        //waypointsController.StartPatrolling();
    }

    public Transform MyInfoVisual {
        get { return myInfoVisual; }
    }
}
