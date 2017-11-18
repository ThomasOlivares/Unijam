using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


    private Action[] actions;
    public int activeActionIndex;
    public float g;
    public float jumpPower, doubleJumpPower, wallJumpPower;
    public float anticipateJump,anticipateWallJump, anticipateFall;
    
    public float  MinXDistWithObjects, MinYDistWithObjects;
    
    // PUBLIC //



    // PRIVATE //
    float time;
    private float height, width;
    bool dessus, dessous, gauche, droite;
    bool landed, right, left;
    float VerticalSpeed, horizontalSpeed;
    private int jumpcount;

    public bool getLanded()
    {
        return landed;
    }
    public bool getLeft()
    {
        return left;
    }
    public bool getRight()
    {
        return right;
    }
    public float CollisionLeft()
    {
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(-width + MinYDistWithObjects, height - MinYDistWithObjects, 0), new Vector3(-1, 0, 0));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(-width + MinYDistWithObjects, 0, 0), new Vector3(-1, 0, 0));
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position + new Vector3(-width + MinYDistWithObjects, -height + MinYDistWithObjects, 0), new Vector3(-1, 0, 0));

        Debug.DrawRay(transform.position + new Vector3(-width, height, 0), new Vector3(-1, 0, 0));
        Debug.DrawRay(transform.position + new Vector3(-width, 0, 0), new Vector3(-1, 0, 0));
        Debug.DrawRay(transform.position + new Vector3(-width, -height, 0), new Vector3(-1, 0, 0));

        float val1 = new float(), val2 = new float(), val3 = new float();
        val1 = -100; val2 = -100; val3 = -100;

        if (hit1)
        {

            val1 = hit1.point.x;
            //print("detect 1 !");
        }
        if (hit2)
        {

            val2 = hit2.point.x;
            //print("detect 2 !");
        }
        if (hit3)
        {

            val3 = hit3.point.x;
            //print("detect 3 !");
        }

        float minX = Mathf.Max(val1, val2, val3) + width + MinXDistWithObjects;

        if (this.gameObject.transform.position.x - minX <= anticipateWallJump)
        {
            right = true;
        }
        else
        {
            right = false;
        }

        return minX;
    }

    public float CollisionRight()
    {
        RaycastHit2D hit4 = Physics2D.Raycast(transform.position + new Vector3(width - MinYDistWithObjects, height - MinYDistWithObjects, 0), new Vector3(1, 0, 0));
        RaycastHit2D hit5 = Physics2D.Raycast(transform.position + new Vector3(width - MinYDistWithObjects, 0, 0), new Vector3(1, 0, 0));
        RaycastHit2D hit6 = Physics2D.Raycast(transform.position + new Vector3(width - MinYDistWithObjects, -height + MinYDistWithObjects, 0), new Vector3(1, 0, 0));

        Debug.DrawRay(transform.position + new Vector3(width, height, 0), new Vector3(1, 0, 0));
        Debug.DrawRay(transform.position + new Vector3(width, 0, 0), new Vector3(1, 0, 0));
        Debug.DrawRay(transform.position + new Vector3(width, -height, 0), new Vector3(1, 0, 0));

        float val4 = new float(), val5 = new float(), val6 = new float();
        val4 = 100; val5 = 100; val6 = 100;

        if (hit4)
        {

            val4 = hit4.point.x;
            //print("detect 4 !");
        }
        if (hit5)
        {

            val5 = hit5.point.x;
            //print("detect 5 !");
        }
        if (hit6)
        {
            val6 = hit6.point.x;
            //print("detect 6 !");
        }

        float maxX = Mathf.Min(val4, val5, val6) - width - MinXDistWithObjects;

        if (maxX - this.gameObject.transform.position.x <= anticipateWallJump)
        {
            left = true;
        }
        else
        {
            left = false;
        }

        return maxX;
    }

    public float CollisionUp()
    {
        RaycastHit2D hit10 = Physics2D.Raycast(transform.position + new Vector3(width - MinYDistWithObjects, height - MinYDistWithObjects, 0), new Vector3(0, 1, 0));
        RaycastHit2D hit11 = Physics2D.Raycast(transform.position + new Vector3(0, height - MinYDistWithObjects, 0), new Vector3(0, 1, 0));
        RaycastHit2D hit12 = Physics2D.Raycast(transform.position + new Vector3(-width + MinYDistWithObjects, height - MinYDistWithObjects, 0), new Vector3(0, 1, 0));

        Debug.DrawRay(transform.position + new Vector3(width, height, 0), new Vector3(0, 1, 0));
        Debug.DrawRay(transform.position + new Vector3(0, height, 0), new Vector3(0, 1, 0));
        Debug.DrawRay(transform.position + new Vector3(-width, height, 0), new Vector3(0, 1, 0));

        float val10 = new float(), val11 = new float(), val12 = new float();
        val10 = 100; val11 = 100; val12 = 100;

        if (hit10)
        {
            val10 = hit10.point.y;
            //print("detect 10 !");
        }
        if (hit11)
        {
            val11 = hit11.point.y;
            //print("detect 11 !");
        }
        if (hit12)
        {
            val12 = hit12.point.y;
            //print("detect 12 !");
        }

        float maxY = Mathf.Min(val10, val11, val12) - height - MinXDistWithObjects;

        if (maxY - this.gameObject.transform.position.y <= anticipateFall && VerticalSpeed > 0)
        {
            VerticalSpeed = 0;
        }
        
        return maxY;
    }

    public float CollisionDown()
    {
        RaycastHit2D hit7 = Physics2D.Raycast(transform.position + new Vector3(width - MinYDistWithObjects, -height + MinYDistWithObjects, 0), new Vector3(0, -1, 0));
        RaycastHit2D hit8 = Physics2D.Raycast(transform.position + new Vector3(0, -height + MinYDistWithObjects, 0), new Vector3(0, -1, 0));
        RaycastHit2D hit9 = Physics2D.Raycast(transform.position + new Vector3(-width + MinYDistWithObjects, -height + MinYDistWithObjects, 0), new Vector3(0, -1, 0));

        Debug.DrawRay(transform.position + new Vector3(width, -height, 0), new Vector3(0, -1, 0));
        Debug.DrawRay(transform.position + new Vector3(0, -height, 0), new Vector3(0, -1, 0));
        Debug.DrawRay(transform.position + new Vector3(-width, -height, 0), new Vector3(0, -1, 0));

        float val7 = new float(), val8 = new float(), val9 = new float();
        val7 = -100; val8 = -100; val9 = -100;

        if (hit7)
        {
            val7 = hit7.point.y;
            //print("detect 7 !");
        }
        if (hit8)
        {
            val8 = hit8.point.y;
            //print("detect 8 !");
        }
        if (hit9)
        {
            val9 = hit9.point.y;
            //print("detect 9 !");
        }

        float minY = Mathf.Max(val7, val8, val9) + height + MinXDistWithObjects;

        float valMin = val7;
        if(Mathf.Abs(valMin-minY) >Mathf.Abs(valMin - val8))
        {
            valMin = val8;
        }
        if(Mathf.Abs(valMin - minY) >Mathf.Abs( valMin - val9))
        {
            valMin = val9;
        }
            

        if (this.gameObject.transform.position.y - minY <= anticipateJump)
        {
            GameObject platf = null;
            MovingPlateforme pltfmvt = null;
            landed = true;
            horizontalSpeed = 0;
            if (val7 == valMin)
            {
                platf = hit7.collider.gameObject;
            }
            else if (val8 == valMin)
            {
                platf = hit8.collider.gameObject;
            }
            else if (val9 == valMin)
            {
                platf = hit9.collider.gameObject;
            }

            if (platf)
            {
                pltfmvt = platf.GetComponent<MovingPlateforme>();
            }
            if (pltfmvt)
            {
                if (pltfmvt.ToTheRight)
                {
                    horizontalSpeed = pltfmvt.Speed.x * Time.deltaTime;
                } else
                {
                    horizontalSpeed = - pltfmvt.Speed.x * Time.deltaTime;
                }
               
                
            }

            if (this.VerticalSpeed <= 0)
            {
                jumpcount = 2;
            }


        }
        else
        {
            landed = false;
            horizontalSpeed = 0;
        }
        return minY;

        

    }


    
    public bool getdessous()
    {
        return dessous;
    }

    public bool getdessus()
    {
        return dessus;
    }

    public bool getgauche()
    {
        return gauche;
    }

    public bool getdroite()
    {
        return droite;
    }

    public void gravity()
    {
        if (!landed)
        {
            VerticalSpeed = VerticalSpeed - g * Time.deltaTime;
            //print(" apply gravity !");
        }
        //print("gravity");
    }

    public void jump()
    {

        if (jumpcount > 0)
        {
            if (landed)
            {
                VerticalSpeed = jumpPower;
                
                jumpcount -= 1;
            }
            else
            {
                if (right)
                {
                    VerticalSpeed = jumpPower;
                    horizontalSpeed = wallJumpPower;
                }
                else if (left)
                {
                    VerticalSpeed = jumpPower;
                    horizontalSpeed = -wallJumpPower;
                }
                else
                {
                    VerticalSpeed = doubleJumpPower;
                  
                    jumpcount -= 1;
                }
            }


        }


    }

    void updateHorizontalSpeed()
    {
        
    }

    public float getVerticalSpeed()
    {
        return VerticalSpeed;
    }

    public float getHorizontalSpeed()
    {
        return horizontalSpeed;
    }
    // Use this for initialization
    void Start () {
        width = this.gameObject.GetComponent<Renderer>().bounds.size.x/2;
        height = this.gameObject.GetComponent<Renderer>().bounds.size.y/2;
        time = 0;
        landed = false;
        right = false;
        left = false;
        VerticalSpeed = 0;
        jumpcount = 2;
        horizontalSpeed = 0;
        actions = GetComponentsInChildren<Action>();
        activeActionIndex = 0;
    }

    void TriggerActive()
    {
        actions[activeActionIndex].Activate(transform.position);
    }

    void ChangeActive()
    {
        if (activeActionIndex < actions.Length - 1)
        {
            activeActionIndex += 1;
        }
        else activeActionIndex = 0;
    }

    // Update is called once per frame
    void Update () {
        gravity();
        updateHorizontalSpeed();
        if (Input.GetButtonDown("Switch")) ChangeActive();
        if (Input.GetButtonDown("Launch")) TriggerActive();
        //print(landed);
    }
}
