using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    public GameObject player;
    GameObject pl;
    bool deathcondition;
    float mv;
    public float camspeed;
	// Use this for initialization
	void Start () {
        pl = GameObject.Instantiate(player);
        deathcondition = false;
        mv = 0;
        camspeed = 5;
        //player = GameObject.Find("Player");
	}

    void MoveCamera()
    {
        mv += Input.GetAxis("Move Camera")*camspeed;
        if (Input.GetAxis("Move Camera") == 0) {
            mv = 0;
        }
    }

    // Update is called once per frame
    void Update () {
        if (deathcondition)
        {
            GameObject.Destroy(pl);
            pl = GameObject.Instantiate(player);
            pl.transform.position = new Vector3(0, 0, 0);
            deathcondition = false;
        }
        if (pl.transform.position.y < -5)
        {
            deathcondition = true;
        }
        this.transform.position = pl.transform.position + new Vector3(mv,0,-8);
	}
}
