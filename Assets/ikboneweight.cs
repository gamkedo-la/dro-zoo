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
    // Needs to be in Update not LateUpdate due to order animation is assessed
    void Update()
    {
        
        constraint.data.targetPositionWeight = weight;

    }
}
