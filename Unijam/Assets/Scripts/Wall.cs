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

    protected override void Activate()
    {
        SpriteRenderer rd = GetComponent<SpriteRenderer>();
        rd.sprite = destroyedSprite;
    }

}
