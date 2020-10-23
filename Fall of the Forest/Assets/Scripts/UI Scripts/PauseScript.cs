using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI_Scripts;
using UnityEngine;

namespace UI_Scripts
{
    public class PauseScript : Menu
    {
        public TextMeshProUGUI[] temp;

        private void OnEnable()
        {
            InitializeMenu(temp);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                Unpause();

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
}
