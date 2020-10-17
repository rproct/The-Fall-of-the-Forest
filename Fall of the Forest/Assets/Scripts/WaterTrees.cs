using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrees : MonoBehaviour
{
    int numWaterBuckets = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "waterBucket")
        {
            numWaterBuckets++;
            Destroy(col.gameObject);
        }
    }
}
