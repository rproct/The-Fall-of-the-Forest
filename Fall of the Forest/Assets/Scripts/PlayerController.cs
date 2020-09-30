using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float height;
    public float jumpForce;
    private Rigidbody rb;
    private bool grounded;
    private Vector3 jump;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, height, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Horizontal");
        if (CanJump()) 
            TriggerJump();

        translation *= Time.deltaTime;
        
        transform.Translate(0, 0, translation);
    }

    private void OnCollisionStay()
    {
        grounded = true;
    }

    private bool CanJump()
    {
        return Input.GetButton("Jump") && grounded;
    }

    private void TriggerJump()
    {
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        grounded = false;
    }
}
