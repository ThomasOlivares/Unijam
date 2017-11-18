using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {


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
            if (Input.GetAxis("Jump") <= 0) ready = true;
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
        float h =Input.GetAxis("Move");
        //float v = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            
            this.GetComponent<Character>().jump();
        }

        //if (((h < 0) && (!this.GetComponent<character>().getdroite())) || ((h > 0) && (!this.GetComponent<character>().getgauche())))
        //{
        //    this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(h * Time.deltaTime * 5, 0, 0);
        //}
        //if (((v < 0) && (!this.GetComponent<character>().getdessus())) || ((v > 0) && (!this.GetComponent<character>().getdessous())))
        //{
        //    this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, v * Time.deltaTime * 5, 0);
        //}
        float minX = this.gameObject.GetComponent<Character>().CollisionLeft();
        float maxX = this.gameObject.GetComponent<Character>().CollisionRight();
        float minY = this.gameObject.GetComponent<Character>().CollisionDown();
        float maxY = this.gameObject.GetComponent<Character>().CollisionUp();
        if (h != 0)
        {
            //print("input");
            
            // check if the cube is in air
            if (!this.gameObject.GetComponent<Character>().getLanded()) currentSpeed = horizontalSpeedInAir;
            else currentSpeed = horizontalSpeed;

            Vector3 pos = this.gameObject.transform.position + new Vector3(h * Time.deltaTime * currentSpeed + this.gameObject.GetComponent<Character>().getHorizontalSpeed(), this.gameObject.GetComponent<Character>().getVerticalSpeed(), 0);
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            this.gameObject.transform.position = pos;
        } else
        {
            Vector3 pos = this.gameObject.transform.position;
            pos.x = Mathf.Clamp(this.gameObject.transform.position.x + this.gameObject.GetComponent<Character>().getHorizontalSpeed(), minX, maxX);
            pos.y = Mathf.Clamp(this.gameObject.transform.position.y + this.gameObject.GetComponent<Character>().getVerticalSpeed(), minY, maxY);
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

