﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionConstantY : MonoBehaviour
{
   
  public Transform follow;
  public float cameraheight;
  public float cameraxoffset;
  public float camerazoffset;
   
    void FixedUpdate()
    {
        Vector3 targetPosition = follow.position;
        //transform.position = new Vector3(follow.position.x  ,cameraheight, follow.position.z );
        transform.position = new Vector3(follow.position.x  ,follow.position.y + cameraheight , follow.position.z );
      }
}
