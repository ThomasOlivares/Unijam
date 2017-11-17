using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Obstacle
{
    void Start()
    {
        type = Obstacle.ObstacleType.Tree;
    }

    Sprite cuttedSprite;
    Sprite destroyedSprite;

    public override bool Activate(Action.ActionType actionType)
    {
        switch (actionType)
        {
            case Action.ActionType.Cut:
                ChangeSprite(cuttedSprite);
                return true;
            case Action.ActionType.Destroy:
                ChangeSprite(destroyedSprite);
                return true;
        }
        return false;
    }
}
