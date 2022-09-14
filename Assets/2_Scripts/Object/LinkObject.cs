using UnityEngine;
using UnityEngine.UI;

public class LinkObject : MonoBehaviour
{
    //�⺻ ����
    [SerializeField] Text nametxt;
    Image _ClipImage;
    GameObject _DeleteWndParent;
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
        GameObject go = transform.GetChild(0).gameObject;
        _ClipImage = go.GetComponent<Image>();
        _ClipImage.sprite = DataPoolManager._instance.GetClipImage(this.IsdollNumber);
        go = GameObject.FindGameObjectWithTag("DeleteParent");
        _DeleteWndParent = go;
    }
    public void DeleteButton()
    {
        GameObject go = DataPoolManager._instance.GetDeleteWnd().gameObject;
        go.GetComponent<DeleteWnd>().SetInit(ClipName, (Utillity.Isdoll)IsdollNumber, ClipURL);
        Instantiate(go , _DeleteWndParent.transform);

        Debug.Log("Ŭ�� �̸� : " + ClipName);
        Debug.Log("Ŭ�� URL  : " + ClipURL);
        Debug.Log("Ŭ���� ���� : IsdolNumber : " + IsdollNumber);
    }

    public void LinkButton()
    {
        try
        {
            if (ClipURL == string.Empty)
            {
                IngameMessageboxUI._instance.IngameMessageTxt("����ִ� ��ũ!");
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
