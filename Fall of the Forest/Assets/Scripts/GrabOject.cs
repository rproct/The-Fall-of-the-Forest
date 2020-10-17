using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    public GameObject item;
    bool playerInRange = false;
    bool beingCarried = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, item.transform.position);

        if (distance <= 2.0f)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }

        if (playerInRange)
        {
            if (Input.GetButtonDown("e"))
            {
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                gameObject.transform.position = player.transform.position + offset;
                gameObject.transform.parent = null;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                beingCarried = true;
            }
        }

        if(beingCarried = true && Input.GetButtonDown("e"))
        {
            beingCarried = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.transform.parent = null;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}