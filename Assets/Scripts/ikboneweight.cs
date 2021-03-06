using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ikboneweight : MonoBehaviour
{
    

    [SerializeField]
    private TwoBoneIKConstraint constraint;
     [SerializeField]
    private float weight;

    [SerializeField]
     private Transform target;
     [SerializeField]
     private Transform source;


    // Needs to be in Update not LateUpdate due to order animation is assessed
    
    void Update()
    {
        float dist = Vector3.Distance(target.position, source.position);
        // print("Distance to target: " + dist);
        if (dist > 1.4) {
            constraint.data.targetPositionWeight = 0f;
        }  else{
        constraint.data.targetPositionWeight = weight * (1 -(dist - 0.8f));
        }
    }
}
