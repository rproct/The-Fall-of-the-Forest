using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI_Scripts;
using UnityEngine;

public class PressStart : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public GameObject other;

    private void OnEnable()
    {
        tmp.faceColor = new Color32(255, 255, 255, 255);
        other.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            StartCoroutine(FadeText.fadeOutText(tmp, gameObject));
    }

    private void OnDisable()
    {
        other.SetActive(true);
    }
}
