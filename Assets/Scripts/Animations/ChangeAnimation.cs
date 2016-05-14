using UnityEngine;
using System.Collections;

public class ChangeAnimation : AnimationBase {

    public override void FinishedRotating()
    {
        base.FinishedRotating();
        //Play here the animation when the occupier stands still:

        animator.Play("still");
    }

    public override void SlowSwim()
    {
        base.SlowSwim();
        //Play here the animation when the occupier is close to its destination, and start rotating to the other occupier:

        animator.Play("swim");
    }

    public override void SwimAway()
    {
        base.SwimAway();
        //play here the animation when the connection has ended, and the occupier swims away


    }
}
