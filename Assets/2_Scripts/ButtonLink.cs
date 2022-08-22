using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class ButtonLink : MonoBehaviour
{
    [SerializeField] GameObject SlotPrefab;

    string Urlstring = "https://www.twitch.tv/gosegugosegu/clip/GorgeousAmazonianSpiderShadyLulu-bqsJct2jbbfbYL8k";
    private void Start()
    {
        Transform go = SlotPrefab.transform.GetChild(0);
        
    }


    public void Clip1_URL()
    {
        Application.OpenURL("https://www.twitch.tv/gosegugosegu/clip/ExuberantDignifiedWalletDancingBaby-FGWXOCQcTo7x58Gp");
    }
    public void Clip2_URL()
    {
        Application.OpenURL("https://www.twitch.tv/gosegugosegu/clip/AmericanGlamorousGullRiPepperonis-Prrfn3aSrAzZE7pG");
    }
    public void Clip3_URL()
    {
        Application.OpenURL("https://www.twitch.tv/gosegugosegu/clip/EnchantingGorgeousLettuceRickroll-AtAP3TpOTd8P9MzL");
    }
    public void Clip4_URL()
    {
        Application.OpenURL("https://www.twitch.tv/gosegugosegu/clip/VivaciousOddTaroDerp-QIxQrDLWGQIYPwRG");
    }
    // 胶农费官 包访 傅农 : https://m.blog.naver.com/eastfever5/222095602409
}
