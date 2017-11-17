using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Obstacle
{
    void Start()
    {
        type = Obstacle.ObstacleType.Wall;
    }

    public Sprite destroyedSprite;

    public override bool Activate(Action.ActionType actionType)
    {
        switch (actionType)
        {
            case Action.ActionType.Destroy:
                ChangeSprite(destroyedSprite);
                return true;
            case Action.ActionType.Move:
                // The wall is not impacted by the player movement
                return true;
        }
        return false;
    }

}
