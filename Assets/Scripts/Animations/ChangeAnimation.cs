using UnityEngine;
using System.Collections;

public class ChangeAnimation : AnimationBase {

    public override void FinishedRotating()
    {
        base.FinishedRotating();
        //Play here the animation when the occupier stands still:

        //animator.Play("StateName");
    }

    public override void SlowSwim()
    {
        base.SlowSwim();
        //Play here the animation when the occupier is close to its destination, and start rotating to the other occupier:

        //animator.Play("StateName");
    }
}
