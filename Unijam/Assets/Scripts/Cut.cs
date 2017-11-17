using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : Action {

	// Use this for initialization
	void Start () {
        type = ActionType.Cut;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Activate(Vector3 positionPlayer)
    {
        foreach (Collider collider in Physics.OverlapSphere(positionPlayer, actionRadius))
        {
            obstacle = collider.gameObject.GetComponent<Obstacle>();
            if (obstacle)
            {
                if (obstacle.type == ObstacleType ;
            }
        }
    }
}
