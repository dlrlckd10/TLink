using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkObject : MonoBehaviour
{
    //기본 정보
    [SerializeField] Text nametxt;
    //[SerializeField] Text Stattxt;
    string ClipName;
    string ClipStat;
    string ClipURL;

    public void InitSet(string ClipName , string ClipStat  , string ClipURL)
    {
        this.ClipName = ClipName;
        this.ClipStat = ClipStat;
        this.ClipURL = ClipURL;
        nametxt.text = ClipName;
    }

    public void LinkButton()
    {
        try
        {
            Application.OpenURL(ClipURL);
        }
        catch(System.NullReferenceException exc)
        {
            Debug.Log(exc);
        }
    }
}
