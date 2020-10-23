using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI_Scripts
{
    public class MainMenuScript : Menu
    {
        public TextMeshProUGUI[] temp;

        public GameObject other;


        private void OnEnable()
        {
            InitializeMenu(temp);
            other.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                foreach (TextMeshProUGUI t in tmps)
                    StartCoroutine(FadeText.fadeOutText(t, gameObject));

            if (Input.anyKey)
                getInput();
            else
                buttonUse = false;
        }

        protected override void executeSelection()
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
}


