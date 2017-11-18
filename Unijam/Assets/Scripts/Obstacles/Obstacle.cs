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
        Cutted, 
        Destroyed,
        StateCount
    }

    protected State state = State.Default;

    [System.NonSerialized] public ObstacleType type;

    public void Start()
    {
    }

    public abstract bool Activate(Action.ActionType actionType);
    
    protected void ChargeAnimation(AnimationClip animation)
    {
        Animator animatorHandler = GetComponent<Animator>();
        animatorHandler.SetBool("onActivate", true);
        /*
        Animation animationHandler = GetComponent<Animation>();
        animationHandler.AddClip(animation, animation.name);
        animationHandler.Play();
        */
    }

    protected void DestroyCollider()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }
}
