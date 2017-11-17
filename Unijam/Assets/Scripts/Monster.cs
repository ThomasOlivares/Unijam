using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Obstacle
{
    void Start()
    {
        type = Obstacle.ObstacleType.Monster;
    }

    public Sprite shottedSprite;

    protected override void Activate()
    {
    }
}
