using UnityEngine;
using System.Collections;

public class AnimationBase : MonoBehaviour {

    private ChangeRotatingTarget changeRotatingTarget;

    private MoveTowards moveTowards;

    protected Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        changeRotatingTarget = GetComponent<ChangeRotatingTarget>();
        moveTowards = GetComponent<MoveTowards>();
    }

    void OnEnable()
    {
        changeRotatingTarget.SlowSwim += SlowSwim;
        moveTowards.FinishedRotating += FinishedRotating;
    }

    void OnDisable()
    {
        changeRotatingTarget.SlowSwim -= SlowSwim;
        moveTowards.FinishedRotating -= FinishedRotating;
    }

    public virtual void SlowSwim()
    {

    }

    public virtual void FinishedRotating() {

    }
}
