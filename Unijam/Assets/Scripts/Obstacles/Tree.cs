using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Obstacle
{
    public new void Start()
    {
        GetComponentInParent<Obstacle>().Start();
        type = Obstacle.ObstacleType.Tree;
    }

    public void Update()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider = new Collider2D();
    }

    // Animations
    public AnimationClip onCut;
    public AnimationClip onDestroyed;

    public override bool Activate(Action.ActionType actionType)
    {
        if (state == State.Default)
        {
            switch (actionType)
            {
                case Action.ActionType.Cut:
                    state = State.Cutted;
                    ChargeAnimation(onCut);
                    return true;
                case Action.ActionType.Destroy:
                    state = State.Destroyed;
                    ChargeAnimation(onDestroyed);
                    DestroyCollider();
                    return true;
            }
        }
        return false;
    }
}
