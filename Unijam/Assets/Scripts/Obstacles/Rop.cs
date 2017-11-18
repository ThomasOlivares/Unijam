using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rop : Obstacle
{
    public new void Start()
    {
        GetComponentInParent<Obstacle>().Start();
        type = Obstacle.ObstacleType.Rop;
    }

    // Animation
    public AnimationClip onCut;

    public override bool Activate(Action.ActionType actionType)
    {
        if (state == State.Default)
        {
            if (actionType == Action.ActionType.Cut || actionType == Action.ActionType.Shoot)
            {
                state = State.Cutted;
                ChargeAnimation(onCut);
                return true;
            }
        }
        return false;
    }
}
