using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI_Scripts
{
    public class FadeText
    {
        public static IEnumerator fadeOutText(TextMeshProUGUI tmp, GameObject go)
        {
            byte alpha = tmp.faceColor.a;
            byte red = tmp.faceColor.r;
            byte green = tmp.faceColor.g;
            byte blue = tmp.faceColor.b;
            int i = getAlphaComparision(0, alpha);
            while (i > 0)
            {
                alpha -= 5;
                yield return new WaitForSecondsRealtime(0.01f);
                tmp.faceColor = new Color32(red, green, blue, alpha);
                i = getAlphaComparision(0, alpha);
            }
            go.SetActive(false);
        }

        private static int getAlphaComparision(byte x, byte y)
        {
            return y.CompareTo(x);
        }
    }
}