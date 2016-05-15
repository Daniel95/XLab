using UnityEngine;
using System.Collections;

public class AnimationBase : MonoBehaviour {

    [SerializeField]
    protected Animator animator;

    [SerializeField]
    private bool adjustAnimSpeedToActualSpeed = true;

    [SerializeField]
    private float fastSwimSpeedMultiplier;

    private ChangeRotatingTarget changeRotatingTarget;

    private MoveTowards moveTowards;

    protected bool trackSpeed = true;

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

    }

    public virtual void FinishedRotating() {
        trackSpeed = false;
    }

    public virtual void SwimAway()
    {
        trackSpeed = true;
        if (adjustAnimSpeedToActualSpeed)
            StartCoroutine(TrackSpeed());
    }

    IEnumerator TrackSpeed() {
        while (trackSpeed) {
            animator.speed = MoveTowards.actualMoveSpeed * fastSwimSpeedMultiplier;
            yield return new WaitForFixedUpdate();
        }
    }
}
