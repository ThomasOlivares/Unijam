using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Obstacle
{
    private State state = State.Default;

    void Start()
    {
        type = Obstacle.ObstacleType.Monster;
    }

    public Sprite deadSprite;
    public Sprite frozenSprite;

    public override bool Activate(Action.ActionType actionType)
    {
        if (state == State.Default)
        {
            switch (actionType)
            {
                case Action.ActionType.Destroy:
                    state = State.Dead;
                    ChangeSprite(deadSprite);
                    return true;
                case Action.ActionType.Freeze:
                    state = State.Frozen;
                    ChangeSprite(frozenSprite);
                    return true;
            }       
        }
        else if (state == State.Frozen && actionType == Action.ActionType.Destroy)
        {
            state = State.Dead;
            ChangeSprite(deadSprite);
            return true;
        }
        return false;
    }
}
