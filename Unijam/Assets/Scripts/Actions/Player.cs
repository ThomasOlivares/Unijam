using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Action[] actions;
    public int activeActionIndex;


    // Use this for initialization
    void Start () {
        actions = GetComponentsInChildren<Action>();
        activeActionIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Switch")) ChangeActive();
        if (Input.GetButtonDown("Launch")) TriggerActive();
    }

    void TriggerActive()
    {
        actions[activeActionIndex].Activate(transform.position);
    }

    void ChangeActive()
    {
        if (activeActionIndex < actions.Length-1)
        {
            activeActionIndex += 1;
        }
        else activeActionIndex = 0;
    }
}
