using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUI : MonoBehaviour
{
    [SerializeField] GameObject DestroyObj;
    public InputField _ClipKindNumberInput;
    public InputField _ClipNameInput;
    public InputField _ClipURLInput;
    int ClipKind = (int)Utillity.Isdoll.INE; // 초기값.
    string ClipUrl;
    string ClipName;

    public void SaveButton()
    {
        
        if(int.TryParse(_ClipKindNumberInput.text , out ClipKind))
        {
            if(!(0 <= ClipKind && ClipKind <= 5))
            {
                IngameMessageboxUI._instance.IngameMessageTxt("클립 종류를 잘못 입력했습니다.\n 0 ~ 5 정수로 입력하세요.");
                Destroy(DestroyObj.gameObject, 2f);
                return;
            }
        }
        else
        {
            IngameMessageboxUI._instance.IngameMessageTxt("클립 종류를 잘못 입력했습니다.\n 0 ~ 5 정수로 입력하세요.");
            Destroy(DestroyObj.gameObject, 2f);
            return;
        }
        ClipName = _ClipNameInput.text;
        ClipUrl = _ClipURLInput.text;

        if (ContainKeyClipName(ClipKind, ClipName))
        {
            IngameMessageboxUI._instance.IngameMessageTxt("'" +ClipName + "' 중복된 클립 이름입니다.");
            Destroy(DestroyObj.gameObject , 2f);
        }
        else
        {
            IngameMessageboxUI._instance.IngameMessageTxt(ClipName + " 저장되었습니다.");
            IngameManager._instance.AddTLink(ClipKind , ClipName , ClipUrl);
            Destroy(DestroyObj.gameObject);
        }
    }

    //각 멤버 별 중복 이름 클립 검사 함수.
    bool ContainKeyClipName(int ClipKindnum , string str)
    {
        switch(ClipKindnum)
        {
            case 0:
                if (IngameManager._instance.INE_ClipURLAndStatusDic.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 1:
                if (IngameManager._instance.JING_ClipURLAndStatusDic.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 2:
                if (IngameManager._instance.LIL_ClipURLAndStatusDic.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 3:
                if (IngameManager._instance.Ju_ClipURLAndStatusDic.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 4:
                if (IngameManager._instance.GO_ClipURLAndStatusDic.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 5:
                if (IngameManager._instance.VII_ClipURLAndStatusDic.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
        }
        return false;
    }

    public void CancleButton()
    {
        Destroy(DestroyObj.gameObject);
    }
}
