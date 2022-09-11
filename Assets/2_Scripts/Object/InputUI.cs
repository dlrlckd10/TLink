using UnityEngine;
using UnityEngine.UI;

public class InputUI : MonoBehaviour
{
    [SerializeField] GameObject DestroyObj;
    public InputField _ClipKindNumberInput;
    public InputField _ClipNameInput;
    public InputField _ClipURLInput;
    int ClipKind;
    string ClipUrl;
    string ClipName;

    public void SaveButton()
    {

        if (int.TryParse(_ClipKindNumberInput.text, out ClipKind))
        {
            if (!(0 <= ClipKind && ClipKind <= 5))
            {
                IngameMessageboxUI._instance.IngameMessageTxt("0~5 ���� �Է�!");
                Destroy(DestroyObj.gameObject, 2f);
                return;
            }
        }
        else
        {
            IngameMessageboxUI._instance.IngameMessageTxt("0~5 ���� �Է�!");
            Destroy(DestroyObj.gameObject, 2f);
            return;
        }
        ClipName = _ClipNameInput.text;
        ClipUrl = _ClipURLInput.text;
        if (ClipUrl == string.Empty || ClipName == string.Empty)
        {
            IngameMessageboxUI._instance.IngameMessageTxt("����ִ�\n�׸� ����!");
            Destroy(DestroyObj.gameObject, 2f);
            return;
        }

        if (ContainKeyClipName(ClipKind, ClipName))
        {
            IngameMessageboxUI._instance.IngameMessageTxt("�ߺ���\nŬ�� �̸�!");
            Destroy(DestroyObj.gameObject, 2f);
            return;
        }
        else
        {
            IngameMessageboxUI._instance.IngameMessageTxt("���� �Ϸ�!");
            IngameManager._instance.AddTLink((Utillity.Isdoll)ClipKind, ClipName, ClipUrl);
            Destroy(DestroyObj.gameObject);
        }
    }

    //�� ��� �� �ߺ� �̸� Ŭ�� �˻� �Լ�.
    bool ContainKeyClipName(int ClipKindnum, string str)
    {
        switch (ClipKindnum)
        {
            case 0:
                if (IngameManager._instance.INE_ClipNameAndURL.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 1:
                if (IngameManager._instance.JING_ClipNameAndURL.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 2:
                if (IngameManager._instance.LIL_ClipNameAndURL.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 3:
                if (IngameManager._instance.JU_ClipNameAndURL.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 4:
                if (IngameManager._instance.GO_ClipNameAndURL.ContainsKey(str))
                {
                    return true;
                }
                else
                    return false;
            case 5:
                if (IngameManager._instance.VII_ClipNameAndURL.ContainsKey(str))
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
