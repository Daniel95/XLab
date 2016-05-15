using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour
{
    //delegate type
    public delegate void DoneRotatingMethods();

    //delegate instance
    public DoneRotatingMethods FinishedRotating;

    //delegate type
    public delegate void ConnectionEndedMethod();

    //delegate instance
    public ConnectionEndedMethod FinishedConnection;

    //delegate type
    public delegate void FinishedMovingMethod();

    //delegate instance
    public FinishedMovingMethod FinishedMoving;

    private float actualMoveSpeed;

    [SerializeField]
    private float vectToTargetMultiplier = 0.008f;

    [SerializeField]
    private float rotateSpeed = 0.05f;

    [SerializeField]
    private float minDistance = 0.05f;

    private Quaternion targetRotation;

    private Vector2 exitPoint;

    public void SetTargetToMove(Vector2 _newTarget)
    {
        StartCoroutine(MoveToTarget(_newTarget));
    }

    public void SetTargetToRotate(Vector2 _newTarget)
    {
        StartCoroutine(RotateToTarget(_newTarget));
    }

    public void SetTargetToUpdateRotating(Transform _newTarget, float _minTime)
    {
        StartCoroutine(UpdatingRotateToTarget(_newTarget, _minTime));
    }

    //move smooth to the target
    IEnumerator MoveToTarget(Vector2 _target) {

        while (Vector2.Distance(transform.position, _target) > minDistance) {
            //the difference in vector to the target
            Vector2 vectorToTarget = _target - new Vector2(transform.position.x, transform.position.y);

            actualMoveSpeed = Mathf.Abs(vectorToTarget.x) + Mathf.Abs(vectorToTarget.y);

            //move towards the target pos
            transform.position += new Vector3(vectorToTarget.x, vectorToTarget.y, 0) * vectToTargetMultiplier;

            yield return new WaitForFixedUpdate();
        }

        if (FinishedMoving != null)
            FinishedMoving();
    }

    //rotate smooth to the target, the target position is not updated
    IEnumerator RotateToTarget(Vector2 _target)
    {
        //the difference in vector to the target
        Vector2 vectorToTarget = _target - new Vector2(transform.position.x, transform.position.y);

        //calculate the angle to our target
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        //use the angle to get the rotation to our target
        targetRotation = Quaternion.Euler(0, 0, angle);

        while (transform.rotation != targetRotation)
        {
            //move to the targetrotation over time
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);
            yield return new WaitForFixedUpdate();
        }
    }
    
    //rotate smooth to the target, and update the targets location.
    //the loop must go on for a minimal time before it can end
    IEnumerator UpdatingRotateToTarget(Transform _target, float _minTime)
    {
        while(_minTime > 0 || transform.rotation != targetRotation)
        {
            //the difference in vector to the target
            Vector2 vectorToTarget = (Vector2)_target.position - new Vector2(transform.position.x, transform.position.y);

            //calculate the angle to our target
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

            //use the angle to get the rotation to our target
            targetRotation = Quaternion.Euler(0, 0, angle);  

            //move to the targetrotation over time
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);

            _minTime--;

            yield return new WaitForFixedUpdate();
        }

        if (FinishedRotating != null)
            FinishedRotating();
    }

    public void MoveAway() {
        //stop all coroutines, so that it no longer rotates, or moves to its old target
        StopAllCoroutines();

        GridController gridController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridController>();

        float xPos = gridController.OccupatedNodesRowsRadius + 7.5f;
        float yPos = gridController.OccupatedNodesRowsRadius + 7.5f;

        if (Random.Range(0, 0.99f) > 0.5f)
            xPos *= -1;
        if (Random.Range(0, 0.99f) > 0.5f)
            yPos *= -1;

        FinishedMoving += DestroySelf;
        StartCoroutine(MoveToTarget(new Vector2(transform.position.x + xPos, transform.position.y + yPos)));
        StartCoroutine(RotateToTarget(new Vector2(transform.position.x + xPos, transform.position.y + yPos)));

        if (FinishedConnection != null)
            FinishedConnection();
    }

    void DestroySelf() {
        FinishedMoving -= DestroySelf;
        Destroy(gameObject);
    }

    public float ActualMoveSpeed {
        get { return actualMoveSpeed; }
    }
}
