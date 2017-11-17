using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
  
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButton("A"))
        //{
        //    handleA();
        //}
        if (Input.GetButton("B"))
        {
            handleB();
        }
        else if (Input.GetButton("X"))
        {
            handleX();
        }
        else if (Input.GetButton("Y"))
        {
            handleY();
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        float JX = Input.GetAxis("Joystick X");
        if (JX != 0)
        {
            handleJoystickX(JX);
        }
        float JY = Input.GetAxis("Joystick Y");
        if (JY != 0)
        {
            handleJoystickX(JY);
        }
    }
   
    
    void handleA()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color(0,1,0);
    }
    void handleB()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
    void handleX()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
    void handleY()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    void handleJoystickX(float x)
    {
        //this.gameObject.transform.position.x = x;
    }
    void handleJoystickY(float y)
    {
        //this.gameObject.transform.position.y = y;
    }
}
