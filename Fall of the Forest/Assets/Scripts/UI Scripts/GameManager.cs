using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Score UI")]
    public GameObject LivesText;
    public GameObject MushroomText;

    private int MushroomCount = 0;
    private int LifeCount = 3;

    private void Start()
    {
        MushroomText.GetComponent<TMPro.TextMeshProUGUI>().text = MushroomCount.ToString();
        LivesText.GetComponent<TMPro.TextMeshProUGUI>().text = LifeCount.ToString();
    }

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

    public void LifeDown()
    {
        LifeCount--;
        LivesText.GetComponent<TMPro.TextMeshProUGUI>().text = LifeCount.ToString();
    }
}
