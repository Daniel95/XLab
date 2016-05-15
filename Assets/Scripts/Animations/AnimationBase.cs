using UnityEngine;
using System.Collections;

public class AnimationBase : MonoBehaviour {

    [SerializeField]
    private bool adjustAnimSpeedToActualSpeed = true;

    [SerializeField]
    private float fastSwimSpeedMultiplier;

    private ChangeRotatingTarget changeRotatingTarget;

    private MoveTowards moveTowards;

    protected Animator animator;

    protected bool tracking = true;

    protected virtual void Awake() {
        changeRotatingTarget = GetComponent<ChangeRotatingTarget>();
        moveTowards = GetComponent<MoveTowards>();

        animator = transform.GetComponentInChildren<Animator>();

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
        tracking = false;
    }

    public virtual void FinishedRotating() {

    }

    public virtual void SwimAway()
    {
        tracking = true;
        if (adjustAnimSpeedToActualSpeed)
            StartCoroutine(TrackSpeed());
    }
    
    IEnumerator TrackSpeed() {
        while (tracking) {
            animator.speed = moveTowards.ActualMoveSpeed * fastSwimSpeedMultiplier;
            yield return new WaitForFixedUpdate();
        }
    }
}
