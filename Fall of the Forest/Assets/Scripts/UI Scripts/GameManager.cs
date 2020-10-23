using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Score UI")]
    public GameObject LivesText = GameObject.Find("Lives Count");
    public GameObject MushroomText = GameObject.Find("Mushroom Count");

    private int MushroomCount = 0;

    //Increment
    public void CollectedMushroom()
    {
            MushroomCount++;
            MushroomText.GetComponent<TMPro.TextMeshProUGUI>().text = MushroomCount.ToString();
    }

    public void UsedMushroom()
    {
        MushroomCount--;
        MushroomText.GetComponent<TMPro.TextMeshProUGUI>().text = MushroomCount.ToString();
    }
}
