using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    //Array to apply parallaxing to:
    public Transform[] backgrounds;      //Array (list) of all the backgrounds
    private float[] parallaxScales;      // The proportion of the camera movement
    public float smoothing =1f;          // How smooth the parallax is going to be. Make sure to set it above 0.

    private Transform cam;               // Ref to main camera transform.
    private Vector3 previousCamPos;      //Store the initial position before next frame.

    //Called before Start(). Great for ref
    private void Awake()
    {
        //Set up the cam ref
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Store the previous frame transform of camera
        previousCamPos = cam.position;

        //Assigning corresponding parallax scales
        parallaxScales = new float[backgrounds.Length];
        for(int i=0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z*-1;    //-1 to get what we want as a background
        }
    }

    // Update is called once per frame
    void Update()
    {
        //For each background 
        for(int i = 0; i < backgrounds.Length; i++)
        {
            // The parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            //Taking movement and multiplying it with scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            //Set a target x position which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //Create a target position which is the background's current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //Fade between current pos and the target pos using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //Set the previous cam pos to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}
