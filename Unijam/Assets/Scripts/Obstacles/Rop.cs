using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rop : Obstacle
{
    void Start()
    {
        type = Obstacle.ObstacleType.Rop;
    }

    Sprite cuttedSprite;

    public override bool Activate(Action.ActionType actionType)
    {
        if (actionType == Action.ActionType.Cut || actionType == Action.ActionType.Shoot)
        {
            ChangeSprite(cuttedSprite);
            return true;
        }
        return false;
    }
}
