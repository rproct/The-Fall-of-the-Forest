using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UI_Scripts;

public class EventScript : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    void Awake()
    {
        tmp.faceColor = new Color32(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            tmp.text = "This tree is dying...\n All it needs it one mushroom to be laid to rest.";
            StartCoroutine(FadeText.fadeInText(tmp));
        }
    }

    private void OnCollisionExit(Collision other)
    {
        StartCoroutine(FadeText.fadeOutText(tmp, null));
    }
}
