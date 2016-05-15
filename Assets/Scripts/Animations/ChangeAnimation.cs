using UnityEngine;
using System.Collections;

public class ChangeAnimation : AnimationBase {

    [SerializeField]
    private float slowSwimSpeed = 0.3f;

    [SerializeField]
    private float finishedRotationSpeed = 0.15f;

    public override void FinishedRotating()
    {
        base.FinishedRotating();
        //Play here the animation when the occupier stands still:
        animator.speed = finishedRotationSpeed;
        animator.Play("still");
    }

    public override void SlowSwim()
    {
        base.SlowSwim();
        //Play here the animation when the occupier is close to its destination, and start rotating to the other occupier:
        animator.speed = slowSwimSpeed;
        animator.Play("swim");
    }

    public override void SwimAway()
    {
        base.SwimAway();
        //play here the animation when the connection has ended, and the occupier swims away
<<<<<<< HEAD
=======
		animator.Play("swim");
>>>>>>> origin/master
    }
}
