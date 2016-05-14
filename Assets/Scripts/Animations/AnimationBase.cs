using UnityEngine;
using System.Collections;

public class AnimationBase : MonoBehaviour {

    [SerializeField]
    private bool adjustAnimSpeedToActualSpeed = true;

    [SerializeField]
    private float animSpeed;

    private ChangeRotatingTarget changeRotatingTarget;

    private MoveTowards moveTowards;

    protected Animator animator;

    protected bool swimming = true;

    private void Awake() {
        animator = GetComponent<Animator>();
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
        swimming = false;
    }

    public virtual void SwimAway()
    {
        swimming = true;
        if (adjustAnimSpeedToActualSpeed)
            StartCoroutine(TrackSpeed());
    }

    IEnumerator TrackSpeed() {
        while (swimming) {
            animator.speed = MoveTowards.actualMoveSpeed * animSpeed;
            yield return new WaitForFixedUpdate();
        }
    }
}
