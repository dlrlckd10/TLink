using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUI : MonoBehaviour
{
    [SerializeField] GameObject DestroyObj;
    public InputField _ClipNameInput;
    public InputField _ClipURLInput;
    int ClipKind = (int)Utillity.Isdoll.INE;
    string ClipUrl;
    string ClipName;

    public void SaveButton()
    {
        //클립 종류 아직 미구현 -> 이 부분은 생각해보기.
        //임시
        
        //

        ClipName = _ClipNameInput.text;
        ClipUrl = _ClipURLInput.text;
        // 저장된 클립 이름과 링크 전달 방식.
        IngameManager._instance.URLAndStatusDic.Add(ClipName, ClipUrl);
        IngameManager._instance.AddTLink(ClipKind);
        Destroy(DestroyObj.gameObject);

    }
    public void CancleButton()
    {
        Destroy(DestroyObj.gameObject);
    }
}
