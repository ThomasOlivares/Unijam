using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateforme : MonoBehaviour {


    public Vector2 Speed;
    public float XOscilDist;
    public float YOscilDist;
    public bool ToTheRight;
    public bool ToTheTop;


    private Vector2 LowBounds, UpBounds;

    // Use this for initialization
    void Start () {
        LowBounds.x = this.gameObject.transform.position.x - XOscilDist;
        LowBounds.y = this.gameObject.transform.position.y - YOscilDist;
        UpBounds.x = this.gameObject.transform.position.x + XOscilDist;
        UpBounds.y = this.gameObject.transform.position.y + YOscilDist;
        if (LowBounds.x > UpBounds.x)
        {
            Debug.Log("Plateform lower bound is bigger than upper on X axis");
            LowBounds.x = UpBounds.x;
        }
        if (LowBounds.y > UpBounds.y)
        {
            Debug.Log("Plateform lower bound is bigger than upper on Y axis");
            LowBounds.y = UpBounds.y;
        }
    }
	
	// Update is called once per frame
	void Update () {
        oscilate();
	}

    void oscilate()
    {
        Vector3 pos = this.gameObject.transform.position;

        if (Speed.x != 0)           // moving on X
        {
            if (ToTheRight && pos.x < UpBounds.x)           // going to the right but not arrived yet
            {
                pos.x += Speed.x * Time.deltaTime;
            }
            else if (ToTheRight && pos.x >= UpBounds.x)     // arrived to right bound
            {
                ToTheRight = false;
            }
            else if (!ToTheRight && pos.x > LowBounds.x)     // going to the left but not arrived yet
            {
                pos.x -= Speed.x * Time.deltaTime;
            }
            else                                            // arrived to right bound
            {
                ToTheRight = true;
            }
        }
        if(Speed.y != 0)       // moving on Y
        {
            if (ToTheTop && pos.y < UpBounds.y)           // going to the top but not arrived yet
            {
                pos.y += Speed.y * Time.deltaTime;
            }
            else if (ToTheTop && pos.y >= UpBounds.y)     // arrived to yop bound
            {
                ToTheTop = false;
            }
            else if (!ToTheTop && pos.y > LowBounds.y)     // going to the bot but not arrived yet
            {
                pos.y -= Speed.y * Time.deltaTime;
            }
            else                                            // arrived to bot bound
            {
                ToTheTop = true;
            }
        }

        this.gameObject.transform.position = pos; // apply changes
    }
}
