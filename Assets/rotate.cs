using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField]
    private GameObject spinthis;
    

    // Update is called once per frame
    void Update()
    {
        spinthis.transform.Rotate (new Vector3 (0, 15, 0) * Time.deltaTime);
    }
}
