using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrees : MonoBehaviour
{
    int numMushrooms = 0;
    string answer;
    public GameObject player;
    public GameObject tree;
    // Start is called before the first frame update
    void Start()
    {

    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "mushroom")
        {
            numMushrooms++;
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "sapling")
        {
            //ask player to select whether they want to cut down tree or save it


            Destroy(col.gameObject);
            if(answer == "save")
            {
                Instantiate(tree);
            } 
            else if(answer == "destroy")
            {
                //say that the tree was destroyed

            }
        }

    }
}
