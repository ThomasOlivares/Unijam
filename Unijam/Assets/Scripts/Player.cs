using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private List<Action> actions;

    // Use this for initialization
    void Start () {
        actions = GetComponents<Action>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
