using UnityEngine;
using System.Collections;

public class ChangeRotatingTarget : MonoBehaviour {

    [SerializeField]
    private float minDistance = 5;

    [SerializeField]
    private int minRotateTime = 200;

    private Transform newTarget;

    public void Instantiate(Transform _newTarget) {
        newTarget = _newTarget;
        StartCoroutine(CheckDistance());
    }

    IEnumerator CheckDistance() {
        //while the distance is too big, do nothing
        while (Vector2.Distance(transform.position, newTarget.position) > minDistance) {
            yield return new WaitForFixedUpdate();
        }

        //rotate to the new target once we are close enough, and update its position
        GetComponent<MoveTowards>().SetTargetToUpdateRotating(newTarget, minRotateTime);
    }

    public Transform NewTarget
    {
        set { newTarget = value; }
    }
}
