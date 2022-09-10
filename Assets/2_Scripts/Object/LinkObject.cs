using UnityEngine;
using UnityEngine.UI;

public class LinkObject : MonoBehaviour
{
    //기본 정보
    [SerializeField] Text nametxt;
    //[SerializeField] Text Stattxt;
    string ClipName;
    string ClipURL;
    int IsdollNumber;

    public void InitSet(int IsdollNumber, string ClipName, string ClipURL)
    {
        this.IsdollNumber = IsdollNumber;
        this.ClipName = ClipName;
        this.ClipURL = ClipURL;
        nametxt.text = ClipName;
    }

    public void LinkButton()
    {
        try
        {
            Application.OpenURL(ClipURL);
        }
        catch (System.NullReferenceException exc)
        {
            Debug.Log(exc);
        }
    }
}
