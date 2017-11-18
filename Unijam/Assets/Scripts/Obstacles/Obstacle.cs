using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour {

    public enum ObstacleType
    {
        Tree, 
        Monster, 
        Water, 
        Rop, 
        Wall, 
        TypeCount
    }

    protected enum State
    {
        Default,
        Frozen,
        Dead,
        StateCount
    }

    public ObstacleType type;

    public Sprite intactSprite;  // first sprite, when the player didn't interact with the object yet

    public abstract bool Activate(Action.ActionType actionType);

    protected void ChangeSprite(Sprite sprite)
    {
        SpriteRenderer rd = GetComponent<SpriteRenderer>();
        rd.sprite = sprite;
    }
}
