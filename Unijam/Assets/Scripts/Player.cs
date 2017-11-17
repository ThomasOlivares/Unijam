using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Action[] actions;
    int activeActionIndex;


    // Use this for initialization
    void Start () {
        actions = GetComponentsInChildren<Action>();
        activeActionIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeActive()
    {
        if (activeActionIndex<actions.size)
    }
}
