using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationBase : MonoBehaviour {

    protected List<Animator> animators = new List<Animator>();

    [SerializeField]
    private bool adjustAnimSpeedToActualSpeed = true;

    [SerializeField]
    private float fastSwimSpeedMultiplier = 0.1f;

    private ChangeRotatingTarget changeRotatingTarget;

    private MoveTowards moveTowards;

    protected bool tracking = true;

    protected virtual void Awake() {
        changeRotatingTarget = GetComponent<ChangeRotatingTarget>();
        moveTowards = GetComponent<MoveTowards>();

        if (GetComponent<Animator>() != null) {
            animators.Add(GetComponent<Animator>());
        }

        foreach (Animator anim in GetComponentsInChildren<Animator>())
        {
            animators.Add(anim);
        }

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
            for (int i = 0; i < animators.Count; i++) {
                animators[i].speed = moveTowards.ActualMoveSpeed * fastSwimSpeedMultiplier;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
