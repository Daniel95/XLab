using UnityEngine;
using System.Collections;

public class AnimationBase : MonoBehaviour {

    [SerializeField]
    protected Animator animator;

    [SerializeField]
    private bool adjustAnimSpeedToActualSpeed = true;

    [SerializeField]
    private float fastSwimAnimSpeed;

    private ChangeRotatingTarget changeRotatingTarget;

    private MoveTowards moveTowards;

    protected bool trackingSpeed = true;

    private void Awake() {
        changeRotatingTarget = GetComponent<ChangeRotatingTarget>();
        moveTowards = GetComponent<MoveTowards>();

        if (adjustAnimSpeedToActualSpeed)
            StartCoroutine(TrackSpeed());
    }

    void OnEnable()
    {
        changeRotatingTarget.SlowSwim += SlowSwim;
        moveTowards.FinishedRotating += FinishedRotating;
        moveTowards.FinishedConnection += SwimAway;
    }

    void OnDisable()
    {
        changeRotatingTarget.SlowSwim -= SlowSwim;
        moveTowards.FinishedRotating -= FinishedRotating;
        moveTowards.FinishedConnection -= SwimAway;
    }

    public virtual void SlowSwim()
    {
        trackingSpeed = false;
    }

    public virtual void FinishedRotating() {

    }

    public virtual void SwimAway()
    {
        trackingSpeed = true;
        if (adjustAnimSpeedToActualSpeed)
            StartCoroutine(TrackSpeed());
    }

    protected IEnumerator TrackSpeed() {
        while (trackingSpeed) {
            animator.speed = MoveTowards.actualMoveSpeed * fastSwimAnimSpeed;
            yield return new WaitForFixedUpdate();
        }
    }
}
