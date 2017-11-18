using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Obstacle
{
    public new void Start()
    {
        GetComponentInParent<Obstacle>().Start();
        type = Obstacle.ObstacleType.Wall;
    }

    // Animation
    public AnimationClip onDestroyed;

    public override bool Activate(Action.ActionType actionType)
    {
        if (state == State.Default)
        {
            switch (actionType)
            {
                case Action.ActionType.Destroy:
                    state = State.Destroyed;
                    ChargeAnimation(onDestroyed);
                    DestroyCollider();
                    return true;
                case Action.ActionType.Move:
                    // The wall is not impacted by the player movement
                    return true;
            }
        }
        return false;
    }

}
