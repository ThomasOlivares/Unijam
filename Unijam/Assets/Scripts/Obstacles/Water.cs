using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Obstacle
{
    void Start()
    {
        type = Obstacle.ObstacleType.Water;
    }

    public override bool Activate(Action.ActionType actionType)
    {

    }
}
