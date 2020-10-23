using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI[] tmps;

    public GameObject other;
    private static readonly Color32 white = new Color32(255, 255, 255, 255);
    private static readonly Color32 yellow = new Color32(201, 171, 0, 255);
    private int selection;
    private bool buttonUse;

    private void OnEnable()
    {
        foreach (TextMeshProUGUI t in tmps)
        {
            t.faceColor = white;
        }
        selection = 0;
        tmps[selection].faceColor = yellow;
        other.SetActive(false);
        buttonUse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
            foreach (TextMeshProUGUI t in tmps)
                StartCoroutine(FadeText.fadeOutText(t, gameObject));
        
        if(Input.GetButtonDown("Submit"))
            executeSelection();
        
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (buttonUse == false)
            {
                changeSelection(1);
                buttonUse = true;
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (buttonUse == false)
            {
                changeSelection(-1);
                buttonUse = true;
            }
        }
        else
            buttonUse = false;
    }

    private void changeSelection(int offset)
    {
        tmps[selection].faceColor = white;
        selection = Math.Abs((selection + offset) % 2);
        tmps[selection].faceColor = yellow;
    }

    private void executeSelection()
    {
        switch (selection)
        {
            case 0:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Main Scene");
                break;
            case 1:
                Application.Quit();
                break;
        }
    }

    private void OnDisable()
    {
        other.SetActive(true);
    }
}


