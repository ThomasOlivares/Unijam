using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    public GameObject player;
    GameObject pl;
    bool deathcondition;
	// Use this for initialization
	void Start () {
        pl = GameObject.Instantiate(player);
        deathcondition = false;
        //player = GameObject.Find("Player");
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
        this.transform.position = pl.transform.position + new Vector3(0,0,-8);
	}
}
