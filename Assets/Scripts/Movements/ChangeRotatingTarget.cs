using UnityEngine;
using System.Collections;

public class ChangeRotatingTarget : MonoBehaviour {

    //delegate type
    public delegate void SlowSwimMethod();

    //delegate instance
    public SlowSwimMethod SlowSwim;

    [SerializeField]
    private float minDistance = 4;

    [SerializeField]
    private int minRotateTime = 135;

    private Transform newTarget;

    private MoveTowards moveTowards;

    void Awake() {
        moveTowards = GetComponent<MoveTowards>();
    }

    void OnEnable()
    {
        moveTowards.FinishedRotating += StartConnectionEffect;
    }

    void OnDisable()
    {
        moveTowards.FinishedRotating -= StartConnectionEffect;
    }

    public void Instantiate(Transform _newTarget) {
        newTarget = _newTarget;
        StartCoroutine(CheckDistance());
    }

    IEnumerator CheckDistance() {
        //while the distance is too big, do nothing
        while (Vector2.Distance(transform.position, newTarget.position) > minDistance) {
            yield return new WaitForFixedUpdate();
        }

        if (SlowSwim != null)
            SlowSwim();

        //rotate to the new target once we are close enough, and update its position
        GetComponent<MoveTowards>().SetTargetToUpdateRotating(newTarget, minRotateTime);
    }

    private void StartConnectionEffect()
    {
        GetComponent<ConnectionEffect>().StartEffect(newTarget);
    }

    public Transform NewTarget
    {
        set { newTarget = value; }
    }
}
