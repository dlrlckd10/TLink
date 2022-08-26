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
        //Ŭ�� ���� ���� �̱��� -> �� �κ��� �����غ���.
        //�ӽ�
        
        //

        ClipName = _ClipNameInput.text;
        ClipUrl = _ClipURLInput.text;
        // ����� Ŭ�� �̸��� ��ũ ���� ���.
        IngameManager._instance.URLAndStatusDic.Add(ClipName, ClipUrl);
        IngameManager._instance.AddTLink(ClipKind);
        Destroy(DestroyObj.gameObject);

    }
    public void CancleButton()
    {
        Destroy(DestroyObj.gameObject);
    }
}
