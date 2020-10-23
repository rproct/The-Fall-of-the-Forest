using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public TextMeshProUGUI[] tmps;
    private int selection;
    private static readonly Color32 white = new Color32(255, 255, 255, 255);
    private static readonly Color32 yellow = new Color32(201, 171, 0, 255);
    private bool buttonUse;
    private void OnEnable()
    {
        foreach (TextMeshProUGUI t in tmps)
        {
            t.faceColor = white;
        }

        selection = 0;
        tmps[selection].faceColor = yellow;
        buttonUse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
            Unpause();
        
        if(Input.GetButtonDown("Submit"))
            executeSelection();
        
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (buttonUse == false)
            {
                changeSelection(1);
                buttonUse = true;
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
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
        selection = (selection + offset) % tmps.Length;
        if (selection < 0)
            selection = tmps.Length - 1;
        tmps[selection].faceColor = yellow;
    }

    private void executeSelection()
    {
        switch (selection)
        {
            case 0:
                Unpause();
                break;
            case 1:
                Unpause();
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager
                    .GetActiveScene().name);
                break;
            case 2:
                Unpause();
                UnityEngine.SceneManagement.SceneManager.LoadScene("Title Scene");
                break;
        }
    }

    private void Unpause()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
