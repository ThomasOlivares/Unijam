using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_controller : MonoBehaviour {


    public float horizontalSpeed, horizontalSpeedInAir;

    private float currentSpeed;

    //void inputColor()
    //{
    //    if (Input.GetButton("Fire1"))
    //    {
    //        //this.gameObject.GetComponent<Renderer>().material.color = Color.green;

    //    } else if (Input.GetButton("Fire2"))
    //    {
    //        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    //    } else if (Input.GetButton("Fire3"))
    //    {
    //        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    //    } else if (Input.GetButton("Jump"))
    //    {
    //        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    //    }
    //}
    struct CrossJump
    {
        public bool ready;
        private bool jumpThisFrame;
        public void checkSiLaToucheEstRelachee()
        {
            if (Input.GetAxis("Jump Cross") <= 0) ready = true;
            else
            {
                if (ready == true)
                {
                    ready = false;
                    jumpThisFrame = true;
                }
            }
        }

        public bool jumpOrder()
        {
            if (jumpThisFrame)
            {
                jumpThisFrame = false;
                return true;
            }
            else return false;
        }
    };
    CrossJump crossJump;

    void inputMoveJoystick()
    {
        crossJump.checkSiLaToucheEstRelachee();
        float h = Input.GetAxis("Horizontal Keyboard arrows") + Input.GetAxis("Horizontal Keyboard zqsd");
        //float v = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump arrows") || Input.GetButtonDown("Jump zqsd"))
        {
            
            this.GetComponent<character>().jump();
        }

        //if (((h < 0) && (!this.GetComponent<character>().getdroite())) || ((h > 0) && (!this.GetComponent<character>().getgauche())))
        //{
        //    this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(h * Time.deltaTime * 5, 0, 0);
        //}
        //if (((v < 0) && (!this.GetComponent<character>().getdessus())) || ((v > 0) && (!this.GetComponent<character>().getdessous())))
        //{
        //    this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, v * Time.deltaTime * 5, 0);
        //}
        float minX = this.gameObject.GetComponent<character>().CollisionLeft();
        float maxX = this.gameObject.GetComponent<character>().CollisionRight();
        float minY = this.gameObject.GetComponent<character>().CollisionDown();
        float maxY = this.gameObject.GetComponent<character>().CollisionUp();
        if (h != 0)
        {
            //print("input");
            
            // check if the cube is in air
            if (!this.gameObject.GetComponent<character>().getLanded()) currentSpeed = horizontalSpeedInAir;
            else currentSpeed = horizontalSpeed;

            Vector3 pos = this.gameObject.transform.position + new Vector3(h * Time.deltaTime * currentSpeed + this.gameObject.GetComponent<character>().getHorizontalSpeed(), this.gameObject.GetComponent<character>().getVerticalSpeed(), 0);
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            this.gameObject.transform.position = pos;
        } else
        {
            Vector3 pos = this.gameObject.transform.position;
            pos.x = Mathf.Clamp(this.gameObject.transform.position.x + this.gameObject.GetComponent<character>().getHorizontalSpeed(), minX, maxX);
            pos.y = Mathf.Clamp(this.gameObject.transform.position.y + this.gameObject.GetComponent<character>().getVerticalSpeed(), minY, maxY);
            this.gameObject.transform.position = pos;
            
        }
       
    }

    // Use this for initialization
    void Start () {
        currentSpeed = horizontalSpeed;

    }
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        //inputColor();
        inputMoveJoystick();
	}
}

