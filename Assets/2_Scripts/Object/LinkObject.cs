using UnityEngine;
using UnityEngine.UI;

public class LinkObject : MonoBehaviour
{
    //기본 정보
    [SerializeField] Text nametxt;
    Image _ClipImage;
    //[SerializeField] Text Stattxt;
    string ClipName;
    string ClipURL;
    int IsdollNumber;
    private void Start()
    {
        
        
    }

    public void InitSet(int IsdollNumber, string ClipName, string ClipURL)
    {
        this.IsdollNumber = IsdollNumber;
        this.ClipName = ClipName;
        this.ClipURL = ClipURL;
        nametxt.text = ClipName;
        GameObject go = transform.GetChild(0).gameObject;
        _ClipImage = go.GetComponent<Image>();
        _ClipImage.sprite = DataPoolManager._instance.GetClipImage(this.IsdollNumber);
    }
    public void DeleteButton()
    {
        Debug.Log("클립 이름 : " + ClipName);
        Debug.Log("클립 URL  : " + ClipURL);
        Debug.Log("클립의 종류 : IsdolNumber : " + IsdollNumber);
    }

    public void LinkButton()
    {
        try
        {
            if (ClipURL == string.Empty)
            {
                IngameMessageboxUI._instance.IngameMessageTxt("비어있는 링크!");
            }
            else
            {
                Application.OpenURL(ClipURL);
            }
        }
        catch (System.NullReferenceException exc)
        {
            Debug.Log(exc);
        }
    }
}
