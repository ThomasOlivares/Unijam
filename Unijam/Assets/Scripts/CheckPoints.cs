using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

    private Vector3 respawnPosition;

    public bool isAlive = true;

	// Use this for initialization
	void Start () {
        respawnPosition = GameObject.Find("Starter").transform.position;
	}

    void Die()
    {
        isAlive = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (!isAlive)
        {
            isAlive = true;
            this.transform.position = respawnPosition + new Vector3(0, 1, 0);
            Debug.Log("hi");
        }
        Collider2D checkpoint = Physics2D.OverlapCircle(this.transform.position, 1);
        if (checkpoint)
        {
            CheckPointsSpawn script = checkpoint.gameObject.GetComponent<CheckPointsSpawn>();
            if (!script.passed)
            {
                script.passed = true;
                respawnPosition = script.transform.position + new Vector3(0, 1, 0);
            }
        }
	}
}
