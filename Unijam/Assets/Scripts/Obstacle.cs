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

    protected ObstacleType type;

    public Sprite intactSprite;  // first sprite, when the player didn't interact with the object yet

    protected abstract void Activate();
}
