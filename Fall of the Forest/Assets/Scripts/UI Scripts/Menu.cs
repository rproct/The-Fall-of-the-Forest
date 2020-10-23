using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI_Scripts
{
    public abstract class Menu : MonoBehaviour
    {
        protected TextMeshProUGUI[] tmps;
        protected int selection;
        protected bool buttonUse;
        protected static readonly Color32 white = new Color32(255, 255, 255, 255);
        protected static readonly Color32 yellow = new Color32(201, 171, 0, 255);

        protected void InitializeMenu(TextMeshProUGUI[] temp)
        {
            tmps = temp;
            foreach (TextMeshProUGUI t in tmps)
            {
                t.faceColor = white;
            }
            selection = 0;
            tmps[selection].faceColor = yellow;
            buttonUse = false;
        }

        protected void getInput()
        {
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
            
        }
        
        private void changeSelection(int offset)
        {
            tmps[selection].faceColor = white;
            selection = (selection + offset) % tmps.Length;
            if (selection < 0)
                selection = tmps.Length - 1;
            tmps[selection].faceColor = yellow;
        }

        protected abstract void executeSelection();
    }
}