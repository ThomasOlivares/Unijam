using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

    public enum ActionType
    {
        Cut,
        Destroy,
        Shoot,
        Move,
        Freeze
    };

    [SerializeField] protected float actionRadius;
    public ActionType type;

    void Activate(Vector3 positionPlayer)
    {
        foreach (Collider collider in Physics.OverlapSphere(positionPlayer, actionRadius))
        {
            Obstacle obstacle = collider.gameObject.GetComponent<Obstacle>();
            if (obstacle)
            {
                if (obstacle.Activate(ActionType.Cut)) Destroy(this);
            }
        }
    }
}
