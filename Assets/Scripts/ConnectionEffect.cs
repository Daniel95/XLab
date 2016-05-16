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

        //point 1
        waypointsController.AddWaypoint(transform.position);

        //point 2:
        Instantiate(pointVisual, (Vector2)transform.position + new Vector2(vectorToTarget.x / 0.7f, vectorToTarget.y / 0.1f), transform.rotation);

        //point 3
        Instantiate(pointVisual, (Vector2)transform.position + new Vector2(vectorToTarget.x / 0.8f, vectorToTarget.y / 0.4f), transform.rotation);

        //point 4
        Instantiate(pointVisual, (Vector2)transform.position + new Vector2(vectorToTarget.x / 0.5f, vectorToTarget.y / 0.5f), transform.rotation);

        //point 5
        Instantiate(pointVisual, (Vector2)transform.position + new Vector2(vectorToTarget.x / 0.2f, vectorToTarget.y / 0.6f), transform.rotation);

        //point 6
        Instantiate(pointVisual, (Vector2)transform.position + new Vector2(vectorToTarget.x / 0.2f, vectorToTarget.y / 0.9f), transform.rotation);

        //point 7
        waypointsController.AddWaypoint(_otherOccupierPosition);

        //point 8
        Instantiate(pointVisual, (Vector2)transform.position + new Vector2(vectorToTarget.x / 0.7f, vectorToTarget.y / 0.05f), transform.rotation);

        //point 9
        Instantiate(pointVisual, (Vector2)transform.position + new Vector2(vectorToTarget.x / 0.7f, vectorToTarget.y / 0.05f), transform.rotation);

        //point 10
        Instantiate(pointVisual, (Vector2)transform.position + new Vector2(vectorToTarget.x / 0.7f, vectorToTarget.y / 0.05f), transform.rotation);

        //point 11
        Instantiate(pointVisual, (Vector2)transform.position + new Vector2(vectorToTarget.x / 0.7f, vectorToTarget.y / 0.05f), transform.rotation);


        waypointsController.AddWaypoint(_otherOccupierPosition);
        

        waypointsController.StartPatrolling();
    }

    public Transform MyInfoVisual {
        get { return myInfoVisual; }
    }
}
