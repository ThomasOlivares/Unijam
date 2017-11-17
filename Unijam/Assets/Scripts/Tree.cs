using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Obstacle
{
    void Start()
    {
        type = Obstacle.ObstacleType.Tree;
    }

    protected override void Activate()
    {

    }
}
