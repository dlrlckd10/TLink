using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeleteWnd : MonoBehaviour
{
    [SerializeField] Text _ClipNameTxt;
    [SerializeField] Text _ClipKindTxt;

    static string _ClipName;
    static Utillity.Isdoll _eisdoll;
    static string _URL;
    public void SetInit(string ClipName , Utillity.Isdoll eIsedoll , string URL)
    {
        _ClipName = ClipName;
        _URL = URL;
        _eisdoll = eIsedoll;
        _ClipNameTxt.text = _ClipName;
        _ClipKindTxt.text = Utillity.ConvertIsedollString(_eisdoll);
    }

    //OK버튼
    public void OkBtn()
    {
        IngameManager._instance.DeleteClip(_eisdoll, _ClipName);
        Destroy(gameObject, 1f);
        
    }
    //Cancel버튼
    public void CancelBtn()
    {
        Destroy(gameObject);
    }
}
