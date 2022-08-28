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
    int ClipKind = (int)Utillity.Isdoll.INE; // �ʱⰪ.
    string ClipUrl;
    string ClipName;

    public void SaveButton()
    {
        
        if(int.TryParse(_ClipKindNumberInput.text , out ClipKind))
        {
            if(!(0 <= ClipKind && ClipKind <= 5))
            {
                IngameMessageboxUI._instance.IngameMessageTxt("Ŭ�� ������ �߸� �Է��߽��ϴ�.\n 0 ~ 5 ������ �Է��ϼ���.");
                Destroy(DestroyObj.gameObject, 2f);
                return;
            }
        }
        else
        {
            IngameMessageboxUI._instance.IngameMessageTxt("Ŭ�� ������ �߸� �Է��߽��ϴ�.\n 0 ~ 5 ������ �Է��ϼ���.");
            Destroy(DestroyObj.gameObject, 2f);
            return;
        }
        ClipName = _ClipNameInput.text;
        ClipUrl = _ClipURLInput.text;

        if (ContainKeyClipName(ClipKind, ClipName))
        {
            IngameMessageboxUI._instance.IngameMessageTxt("'" +ClipName + "' �ߺ��� Ŭ�� �̸��Դϴ�.");
            Destroy(DestroyObj.gameObject , 2f);
        }
        else
        {
            IngameMessageboxUI._instance.IngameMessageTxt(ClipName + " ����Ǿ����ϴ�.");
            IngameManager._instance.AddTLink(ClipKind , ClipName , ClipUrl);
            Destroy(DestroyObj.gameObject);
        }
    }

    //�� ��� �� �ߺ� �̸� Ŭ�� �˻� �Լ�.
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
