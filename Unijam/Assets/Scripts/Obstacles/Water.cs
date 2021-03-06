﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Obstacle
{
    public new void Start()
    {
        GetComponentInParent<Obstacle>().Start();
        type = Obstacle.ObstacleType.Water;
    }

    // Animations
    public AnimationClip onFroze;

    public override bool Activate(Action.ActionType actionType)
    {
        if (state == State.Default)
        {
            switch (actionType)
            {
                case Action.ActionType.Freeze:
                    state = State.Frozen;
                    ChargeAnimation(onFroze);
                    return true;
                case Action.ActionType.Move:
                    // doesn't affect the water
                    return true;
            }
        }
        return false;
    }
}
