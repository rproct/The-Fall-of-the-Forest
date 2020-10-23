using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    private float speed = 0.25f;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(1f, 0f, 0f);
        
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
