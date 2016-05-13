﻿using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour
{
    //delegate type
    public delegate void DoneRotatingMethods();

    //delegate instance
    public DoneRotatingMethods FinishedRotating;

    [SerializeField]
    private float speed = 0.008f;

    [SerializeField]
    private float rotateSpeed = 0.05f;

    [SerializeField]
    private float minDistance = 0.05f;

    [SerializeField]
    private bool correctRotation = true;

    private Vector3 correctedRotation = new Vector3(0, 0, 0);

    private Quaternion targetRotation;

    private void Awake() {
        if (correctRotation)
            correctedRotation = new Vector3(0, 270, 270);

        transform.rotation = Quaternion.Euler(0, 270, 270);
    }

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

            //move towards the target pos
            transform.position += new Vector3(vectorToTarget.x, vectorToTarget.y, 0) * speed;

            yield return new WaitForFixedUpdate();
        }
    }

    //rotate smooth to the target, the target position is not updated
    IEnumerator RotateToTarget(Vector2 _target)
    {
        //the difference in vector to the target
        Vector2 vectorToTarget = _target - new Vector2(transform.position.x, transform.position.y);

        //calculate the angle to our target
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        //use the angle to get the rotation to our target
        targetRotation = Quaternion.Euler(angle, correctedRotation.y, correctedRotation.z);

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
            targetRotation = Quaternion.Euler(angle, correctedRotation.y, correctedRotation.z);

            //move to the targetrotation over time
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed);

            _minTime--;

            yield return new WaitForFixedUpdate();
        }

        if (FinishedRotating != null)
            FinishedRotating();
    }

    public void MoveAway() {
        Destroy(gameObject);
    }
}
