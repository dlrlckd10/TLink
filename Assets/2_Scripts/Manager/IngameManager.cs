using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
using System;
using LitJson;
using System.IO;
using System.Text;
//
public class IngameManager : MonoBehaviour
{
    public static IngameManager _uniqueInstance;
    public static IngameManager _instance
    {
        get { return _uniqueInstance; }
    }

    [SerializeField] Transform Initpos;
    [SerializeField] GameObject ClipPrefab;
    [SerializeField] Transform ClipParent;
    [SerializeField] Transform InputUIParent;
    [SerializeField] GameObject InputUIWnd;
    [SerializeField] Dropdown KindDropdown;
    Image _bg;
    //public ScrollRect uiScrollRect;

    // Key : URL Name - List�� ���� �� �����Ѵ�. / Value : URL ��ũ
    //INE
    public Dictionary<string, string> INE_ClipNameAndURL = new Dictionary<string, string>();
    public List<string> INE_URLNameList = new List<string>();
    //Jing
    public Dictionary<string, string> JING_ClipNameAndURL = new Dictionary<string, string>();
    public List<string> JING_URLNameList = new List<string>();
    //LiL
    public Dictionary<string, string> LIL_ClipNameAndURL = new Dictionary<string, string>();
    public List<string> LIL_URLNameList = new List<string>();
    //Ju
    public Dictionary<string, string> JU_ClipNameAndURL = new Dictionary<string, string>();
    public List<string> JU_URLNameList = new List<string>();
    //Go
    public Dictionary<string, string> GO_ClipNameAndURL = new Dictionary<string, string>();
    public List<string> GO_URLNameList = new List<string>();
    //VII
    public Dictionary<string, string> VII_ClipNameAndURL = new Dictionary<string, string>();
    public List<string> VII_URLNameList = new List<string>();

    //Clip ����
    float ClipDistance = -200f;
    public ScrollViewController _scrollView;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _uniqueInstance = this;
    }

    void Start()
    {
#if(UNITY_EDITOR)
        FlieLoad();
#else
        string path = Application.persistentDataPath;
        WindowFileLoad(path);
#endif
        GameObject go = GameObject.FindGameObjectWithTag("MapBG");
        _bg = go.transform.GetComponent<Image>();
        _bg.sprite = DataPoolManager._instance.GetRandomBG();
    }

    //���� �� ��ü �ε� �Լ�.
    public void WindowFileLoad(string path)
    {
        //���̳� ���� �б�. 
        if (File.Exists(path + "/INEDic.Json") && File.Exists(path + "/INEList.Json"))
        {
            string DicJsonStr = File.ReadAllText(path + "/INEDic.Json");
            string LIstJsonStr = File.ReadAllText(path + "/INEList.Json");
            if (DicJsonStr != null || LIstJsonStr != null)
            {
                JsonLoad(Utillity.Isdoll.INE, DicJsonStr, LIstJsonStr);
            }
        }
        //¡���� ���� �б�
        if (File.Exists(path + "/JingburgerDic.Json") && File.Exists(path + "/JingburgerList.Json"))
        {
            string DicJsonStr = File.ReadAllText(path + "/JingburgerDic.Json");
            string LIstJsonStr = File.ReadAllText(path + "/JingburgerList.Json");
            if (DicJsonStr != null || LIstJsonStr != null)
            {
                JsonLoad(Utillity.Isdoll.JING , DicJsonStr, LIstJsonStr);
            }
        }
        //���� ���� �б�.
        if (File.Exists(path + "/LilpaDic.Json") && File.Exists(path + "/LilpaList.Json"))
        {
            string DicJsonStr = File.ReadAllText(path + "/LilpaDic.Json");
            string LIstJsonStr = File.ReadAllText(path + "/LilpaList.Json");
            if (DicJsonStr != null || LIstJsonStr != null)
            {
                JsonLoad(Utillity.Isdoll.LiLL, DicJsonStr, LIstJsonStr);
            }
        }
        //�ָ��� ���� �б�.
        if (File.Exists(path + "/JururuDic.Json") && File.Exists(path + "/JururuList.Json"))
        {
            string DicJsonStr = File.ReadAllText(path + "/JururuDic.Json");
            string LIstJsonStr = File.ReadAllText(path + "/JururuList.Json");
            if (DicJsonStr != null || LIstJsonStr != null)
            {
                JsonLoad(Utillity.Isdoll.JU, DicJsonStr, LIstJsonStr);
            }
        }
        //���� ���� �б�.
        if (File.Exists(path + "/GoseguDic.Json") && File.Exists(path + "/GoseguList.Json")) // //
        {
            string DicJsonStr = File.ReadAllText(path + "/GoseguDic.Json"); //
            string LIstJsonStr = File.ReadAllText(path + "/GoseguList.Json"); // 
            if (DicJsonStr != null || LIstJsonStr != null)
            {
                JsonLoad(Utillity.Isdoll.Go, DicJsonStr, LIstJsonStr);
            }
        }
        //��î ���� �б�.
        if (File.Exists(path + "/ViichanDic.Json") && File.Exists(path + "/ViichanList.Json")) // //
        {
            string DicJsonStr = File.ReadAllText(path + "/ViichanDic.Json"); //
            string LIstJsonStr = File.ReadAllText(path + "/ViichanList.Json"); // 
            if (DicJsonStr != null || LIstJsonStr != null)
            {
                JsonLoad(Utillity.Isdoll.VII, DicJsonStr, LIstJsonStr);
            }
        }
    }
    //����Ƽ ������ ���� - ��ü ���� ���� �ε�.
    public void FlieLoad()
    {
        TextAsset DictextAsset = Resources.Load("INEDic") as TextAsset;
        TextAsset ListtextAsset = Resources.Load("INEList") as TextAsset;
        if (DictextAsset != null || ListtextAsset != null)
        {
            JsonLoad(Utillity.Isdoll.INE, DictextAsset.text, ListtextAsset.text);
        }

        //¡����
        DictextAsset = Resources.Load("JingburgerDic") as TextAsset;
        ListtextAsset = Resources.Load("JingburgerList") as TextAsset;
        if (DictextAsset != null || ListtextAsset != null)
        {
            JsonLoad(Utillity.Isdoll.JING, DictextAsset.text, ListtextAsset.text);
        }

        //����
        DictextAsset = Resources.Load("LilpaDic") as TextAsset;
        ListtextAsset = Resources.Load("LilpaList") as TextAsset;
        if (DictextAsset != null || ListtextAsset != null)
        {
            JsonLoad(Utillity.Isdoll.LiLL, DictextAsset.text, ListtextAsset.text);
        }

        //�ָ���
        DictextAsset = Resources.Load("JururuDic") as TextAsset;
        ListtextAsset = Resources.Load("JururuList") as TextAsset;
        if (DictextAsset != null || ListtextAsset != null)
        {
            JsonLoad(Utillity.Isdoll.JU, DictextAsset.text, ListtextAsset.text);
        }

        //����
        DictextAsset = Resources.Load("GoseguDic") as TextAsset;
        ListtextAsset = Resources.Load("GoseguList") as TextAsset;
        if (DictextAsset != null || ListtextAsset != null)
        {
            JsonLoad(Utillity.Isdoll.Go, DictextAsset.text, ListtextAsset.text);
        }

        //��î
        DictextAsset = Resources.Load("ViichanDic") as TextAsset;
        ListtextAsset = Resources.Load("ViichanList") as TextAsset;
        if (DictextAsset != null || ListtextAsset != null)
        {
            JsonLoad(Utillity.Isdoll.VII, DictextAsset.text, ListtextAsset.text);
        }

    }

    //���ο� Ŭ�� ���� �� Dic / List ���� �� ���� ���� ����
    public void AddTLink(Utillity.Isdoll eIsdollKind, string ClipName, string ClipURL)
    {
        switch (eIsdollKind)
        {
            case Utillity.Isdoll.INE:
                INE_URLNameList.Add(ClipName);
                INE_ClipNameAndURL.Add(ClipName, ClipURL);
                break;
            case Utillity.Isdoll.JING:
                JING_URLNameList.Add(ClipName);
                JING_ClipNameAndURL.Add(ClipName, ClipURL);
                break;
            case Utillity.Isdoll.LiLL:
                LIL_URLNameList.Add(ClipName);
                LIL_ClipNameAndURL.Add(ClipName, ClipURL);
                break;
            case Utillity.Isdoll.JU:
                JU_URLNameList.Add(ClipName);
                JU_ClipNameAndURL.Add(ClipName, ClipURL);
                break;
            case Utillity.Isdoll.Go:
                GO_URLNameList.Add(ClipName);
                GO_ClipNameAndURL.Add(ClipName, ClipURL);
                break;
            case Utillity.Isdoll.VII:
                VII_URLNameList.Add(ClipName);
                VII_ClipNameAndURL.Add(ClipName, ClipURL);
                break;
        }
        SaveIsdolClip(eIsdollKind);
        ClipReset(eIsdollKind); //-> ���ο� Ŭ���� �����ϴ� ��� -> ���ο� Ŭ���� ������ ����.
        // DropDown ����
        KindDropdown.value = (int)eIsdollKind + 1; // none�� 0�̹Ƿ� 
        //
    }

    //�̼��� �׸��� �����ϴ� ���. �����ϴ� �Լ�.
    public void SelectDropdown() 
    {
        switch (KindDropdown.value)
        {
            case 0: // none.
                DeleteClipList();
                break;
            case 1: // INE
                ClipReset(Utillity.Isdoll.INE);
                break;
            case 2: // JING
                ClipReset(Utillity.Isdoll.JING);
                break;
            case 3: // LIL
                ClipReset(Utillity.Isdoll.LiLL);
                break;
            case 4: // JU
                ClipReset(Utillity.Isdoll.JU);
                break;
            case 5: // GO
                ClipReset(Utillity.Isdoll.Go);
                break;
            case 6: // VII
                ClipReset(Utillity.Isdoll.VII);
                break;
        }
    }

    //������ �ڷᱸ�� ���� �Լ�
    public void SaveIsdolClip(Utillity.Isdoll eIsedoll)
    {
        switch (eIsedoll)
        {
            case Utillity.Isdoll.INE:
                {
                    //Dic ����
#if (UNITY_EDITOR)
                    string fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "INEDic.Json";
#else
                    string fullpath = Application.persistentDataPath + "/INEDic" + ".Json";
#endif
                    StreamWriter fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonDic("INEDic", fullpath, INE_ClipNameAndURL, fileWrite);
                    fileWrite.Close();
                    //
                    //Ket List����
#if(UNITY_EDITOR)
                    fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "INEList.Json";
#else
                    fullpath = Application.persistentDataPath + "/INEList" + ".Json";
#endif
                    fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonList("INEList", fullpath, INE_URLNameList, fileWrite);
                    fileWrite.Close();
                    //
                }
                break;
            case Utillity.Isdoll.JING:
                {
                    //Dic ����
#if (UNITY_EDITOR)
                    string fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "JingburgerDic.Json";
#else
                    string fullpath = Application.persistentDataPath + "/JingburgerDic.Json";
#endif
                    StreamWriter fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonDic("JingburgerDic", fullpath, JING_ClipNameAndURL, fileWrite);
                    fileWrite.Close();
                    //
                    //Ket List����
#if (UNITY_EDITOR)
                    fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "JingburgerList.Json";
#else
                    fullpath = Application.persistentDataPath + "/JingburgerList.Json";
#endif
                    fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonList("JingburgerList", fullpath, JING_URLNameList, fileWrite);
                    fileWrite.Close();
                    //
                }
                break;
            case Utillity.Isdoll.LiLL:
                {
                    //Dic ����
#if (UNITY_EDITOR)
                    string fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "LilpaDic.Json";
#else
                    string fullpath = Application.persistentDataPath + "/LilpaDic.Json";
#endif
                    StreamWriter fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonDic("LilpaDic", fullpath, LIL_ClipNameAndURL, fileWrite);
                    fileWrite.Close();
                    //
                    //Ket List����
#if (UNITY_EDITOR)
                    fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "LilpaList.Json";
#else
                    fullpath = Application.persistentDataPath + "/LilpaList.Json";
#endif
                    fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonList("LilpaList", fullpath, LIL_URLNameList, fileWrite);
                    fileWrite.Close();
                    //
                }
                break;
            case Utillity.Isdoll.JU:
                {
                    //Dic ����
#if (UNITY_EDITOR)
                    string fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "JururuDic.Json";
#else
                    string fullpath = Application.persistentDataPath + "/JururuDic.Json";
#endif
                    StreamWriter fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonDic("JururuDic", fullpath, JU_ClipNameAndURL, fileWrite);
                    fileWrite.Close();
                    //
                    //Ket List����
#if (UNITY_EDITOR)
                    fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "JururuList.Json";
#else
                    fullpath = Application.persistentDataPath + "/JururuList.Json";
#endif
                    fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonList("JururuList", fullpath, JU_URLNameList, fileWrite);
                    fileWrite.Close();
                    //
                }
                break;
            case Utillity.Isdoll.Go:
                {
                    //Dic ����
#if (UNITY_EDITOR)
                    string fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "GoseguDic.Json";
#else
                    string fullpath = Application.persistentDataPath + "/GoseguDic.Json";
#endif
                    StreamWriter fileWrite = new StreamWriter(fullpath, false,Encoding.Unicode);
                    SaveJsonDic("GoseguDic", fullpath, GO_ClipNameAndURL, fileWrite);
                    fileWrite.Close();
                    //
                    //Ket List����
#if (UNITY_EDITOR)
                    fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "GoseguList.Json";
#else
                    fullpath = Application.persistentDataPath + "/GoseguList.Json";
#endif
                    fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonList("GoseguList", fullpath , GO_URLNameList, fileWrite);
                    fileWrite.Close();
                    //
                }
                break;
            case Utillity.Isdoll.VII:
                {
                    //Dic ����
#if (UNITY_EDITOR)
                    string fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "ViichanDic.Json";
#else
                    string fullpath = Application.persistentDataPath + "/ViichanDic.Json";
#endif
                    StreamWriter fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonDic("ViichanDic", fullpath, VII_ClipNameAndURL, fileWrite);
                    fileWrite.Close();
                    //
                    //Ket List����
#if (UNITY_EDITOR)
                    fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "ViichanList.Json";
#else
                    fullpath = Application.persistentDataPath + "/ViichanList.Json";
#endif
                    fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonList("ViichanList", fullpath, VII_URLNameList, fileWrite);
                    fileWrite.Close();
                    //
                }
                break;
        }
    }

    // Ŭ�� ���� ��ư
    public void ClipReset(Utillity.Isdoll eIsedoll)
    {
        GameObject scollobj = GameObject.FindGameObjectWithTag("ScrollView");
        _scrollView = scollobj.GetComponent<ScrollViewController>();
        Vector3 DistancPos = Initpos.position;
        _scrollView.ResetSpace();
        //���� ������ �ڽ� ��ü ����.
        if(ClipParent.childCount != 0)
            DeleteClipList();
        switch (eIsedoll)
        {
            case Utillity.Isdoll.INE:
                for (int n = 0; n < INE_ClipNameAndURL.Count; n++)
                {
                    int Isdollnum = (int)Utillity.Isdoll.INE;
                    string ClipName = INE_URLNameList[n].ToString();
                    string Url = INE_ClipNameAndURL[INE_URLNameList[n].ToString()];

                    _scrollView.AddSpace(ClipPrefab, Isdollnum, ClipName, Url, ClipDistance);
                }
                break;
            case Utillity.Isdoll.JING:
                for (int n = 0; n < JING_ClipNameAndURL.Count; n++)
                {
                    int Isdollnum = (int)Utillity.Isdoll.JING;
                    string ClipName = JING_URLNameList[n].ToString();
                    string Url = JING_ClipNameAndURL[JING_URLNameList[n].ToString()];
                    _scrollView.AddSpace(ClipPrefab, Isdollnum, ClipName , Url , ClipDistance);
                }
                break;
            case Utillity.Isdoll.LiLL:
                for (int n = 0; n < LIL_ClipNameAndURL.Count; n++)
                {
                    int Isdollnum = (int)Utillity.Isdoll.LiLL; 
                    string ClipName = LIL_URLNameList[n].ToString(); 
                    string Url = LIL_ClipNameAndURL[LIL_URLNameList[n].ToString()];
                    _scrollView.AddSpace(ClipPrefab, Isdollnum, ClipName, Url, ClipDistance);
                }
                break;
            case Utillity.Isdoll.JU:
                for (int n = 0; n < JU_ClipNameAndURL.Count; n++) 
                {
                    int Isdollnum = (int)Utillity.Isdoll.JU; 
                    string ClipName = JU_URLNameList[n].ToString(); 
                    string Url = JU_ClipNameAndURL[JU_URLNameList[n].ToString()];
                    _scrollView.AddSpace(ClipPrefab, Isdollnum, ClipName, Url, ClipDistance);
                }
                break;
            case Utillity.Isdoll.Go:
                for (int n = 0; n < GO_ClipNameAndURL.Count; n++) 
                {
                    int Isdollnum = (int)Utillity.Isdoll.Go; 
                    string ClipName = GO_URLNameList[n].ToString(); 
                    string Url = GO_ClipNameAndURL[GO_URLNameList[n].ToString()];
                    _scrollView.AddSpace(ClipPrefab, Isdollnum, ClipName, Url, ClipDistance);

                }
                break;
            case Utillity.Isdoll.VII:
                for (int n = 0; n < VII_ClipNameAndURL.Count; n++) 
                {
                    int Isdollnum = (int)Utillity.Isdoll.VII; 
                    string ClipName = VII_URLNameList[n].ToString(); 
                    string Url = VII_ClipNameAndURL[VII_URLNameList[n].ToString()];
                    _scrollView.AddSpace(ClipPrefab, Isdollnum, ClipName, Url, ClipDistance);
                }
                break;
        }
    }

    // ���� �� ���� ������ Ŭ�� ������ ���� �Լ�
    void DeleteClipList()
    {
        for (int n = 0; n < ClipParent.childCount; n++)
        {
            if (ClipParent.transform.GetChild(n) != null)
            {
                Destroy(ClipParent.transform.GetChild(n).gameObject);
            }
        }
    }
    // ������ ���� Json Load�Լ�.
    void JsonLoad(Utillity.Isdoll isdoll , string Dictxt , string Listtxt)
    {
        switch (isdoll)
        {
            case Utillity.Isdoll.INE:
                {
                    JsonData mydata = JsonMapper.ToObject(Listtxt);
                    INE_URLNameList.Clear();
                    INE_ClipNameAndURL.Clear();
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        INE_URLNameList.Add(mydata[0][0][n].ToString());
                    }
                    mydata = JsonMapper.ToObject(Dictxt);
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        //Key
                        string key = INE_URLNameList[n].ToString();
                        //Value 
                        string value = mydata[0][0][INE_URLNameList[n]].ToString();
                        INE_ClipNameAndURL.Add(key, value);
                    }
                }
                break;
            case Utillity.Isdoll.JING:
                {
                    JsonData mydata = JsonMapper.ToObject(Listtxt);
                    JING_URLNameList.Clear();
                    JING_ClipNameAndURL.Clear();
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        JING_URLNameList.Add(mydata[0][0][n].ToString());
                    }
                    mydata = JsonMapper.ToObject(Dictxt);
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        //Key
                        string key = JING_URLNameList[n].ToString();
                        //Value 
                        string value = mydata[0][0][JING_URLNameList[n]].ToString();
                        JING_ClipNameAndURL.Add(key, value);
                    }
                }
                break;
            case Utillity.Isdoll.LiLL:
                {
                    JsonData mydata = JsonMapper.ToObject(Listtxt);
                    LIL_URLNameList.Clear();
                    LIL_ClipNameAndURL.Clear();
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        LIL_URLNameList.Add(mydata[0][0][n].ToString());
                    }
                    mydata = JsonMapper.ToObject(Dictxt);
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        //Key
                        string key = LIL_URLNameList[n].ToString();
                        //Value 
                        string value = mydata[0][0][LIL_URLNameList[n]].ToString();
                        LIL_ClipNameAndURL.Add(key, value);
                    }
                }
                break;
            case Utillity.Isdoll.JU:
                {
                    JsonData mydata = JsonMapper.ToObject(Listtxt);
                    JU_URLNameList.Clear();
                    JU_ClipNameAndURL.Clear();
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        JU_URLNameList.Add(mydata[0][0][n].ToString());
                    }
                    mydata = JsonMapper.ToObject(Dictxt);
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        //Key
                        string key = JU_URLNameList[n].ToString();
                        //Value 
                        string value = mydata[0][0][JU_URLNameList[n]].ToString();
                        JU_ClipNameAndURL.Add(key, value);
                    }
                }
                break;
            case Utillity.Isdoll.Go:
                {
                    JsonData mydata = JsonMapper.ToObject(Listtxt);
                    GO_URLNameList.Clear();
                    GO_ClipNameAndURL.Clear();
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        GO_URLNameList.Add(mydata[0][0][n].ToString());
                    }
                    mydata = JsonMapper.ToObject(Dictxt);
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        //Key
                        string key = GO_URLNameList[n].ToString();
                        //Value 
                        string value = mydata[0][0][GO_URLNameList[n]].ToString();
                        GO_ClipNameAndURL.Add(key, value);
                    }
                }
                break;
            case Utillity.Isdoll.VII:
                {
                    JsonData mydata = JsonMapper.ToObject(Listtxt);
                    VII_URLNameList.Clear();
                    VII_ClipNameAndURL.Clear();
                    for (int n = 0; n < mydata[0][0].Count; n++)
                    {
                        VII_URLNameList.Add(mydata[0][0][n].ToString());
                    }
                    mydata = JsonMapper.ToObject(Dictxt);
                    for(int n = 0; n < mydata[0][0].Count; n++)
                    {
                        //Key
                        string key = VII_URLNameList[n].ToString();
                        //Value 
                        string value = mydata[0][0][VII_URLNameList[n]].ToString();
                        VII_ClipNameAndURL.Add(key, value);
                    }
                }
                break;
        }
    }
    // Dic - Json���� �Լ�.
    void SaveJsonDic(string Filename , string path, Dictionary<string, string> Dic, StreamWriter streamWt)
    {
        JsonWriter jsonWriter = new JsonWriter(streamWt);
        jsonWriter.WriteObjectStart(); //��ü �߰�ȣ ����
        jsonWriter.WritePropertyName(Filename);
        jsonWriter.WriteArrayStart();// ��ü ���ȣ ����
        //�����ۼ�.
        jsonWriter.WriteObjectStart();//�ʵ� ��ȣ.
        foreach (KeyValuePair<string, string> test in Dic)
        {
            jsonWriter.WritePropertyName(test.Key.ToString());
            jsonWriter.Write(test.Value.ToString());
        }
        jsonWriter.WriteObjectEnd(); // �ʵ��ȣ �ݱ�.
        jsonWriter.WriteArrayEnd(); // ��ü ���ȣ �ݱ�
        jsonWriter.WriteObjectEnd(); // ��ü �߰�ȣ �ݱ�.
    }
    // List - Json ���� �Լ�.
    void SaveJsonList(string Filename , string path, List<string> list, StreamWriter streamWt)
    {
        JsonWriter jsonWriter = new JsonWriter(streamWt);
        jsonWriter.WriteObjectStart(); //��ü �߰�ȣ ����
        jsonWriter.WritePropertyName(Filename);
        jsonWriter.WriteArrayStart();// ��ü ���ȣ ����
        //�����ۼ�.
        jsonWriter.WriteObjectStart();//�ʵ� ��ȣ.
        //List ����.
        for (int n = 0; n < list.Count; n++)
        {
            jsonWriter.WritePropertyName(n.ToString());
            jsonWriter.Write(list[n].ToString());
        }
        //
        jsonWriter.WriteObjectEnd(); // �ʵ��ȣ �ݱ�.
        jsonWriter.WriteArrayEnd(); // ��ü ���ȣ �ݱ�
        jsonWriter.WriteObjectEnd(); // ��ü �߰�ȣ �ݱ�.
    }

    // ����� Ŭ�� ���� �Լ�.
    public void DeleteClip(Utillity.Isdoll eIsedoll , string ClipName)
    {
        DicAndListDelete(eIsedoll, ClipName);
        // �ٽ� Json���� ����.
        SaveIsdolClip(eIsedoll);
        // ����
        ClipReset(eIsedoll);

    }
    //�ڷ� ���� �����Լ�,
    public void DicAndListDelete(Utillity.Isdoll eIsodoll, string ClipName)
    {
        Debug.Log(eIsodoll); // INE
        Debug.Log(ClipName); // null
        switch (eIsodoll)
        {
            case Utillity.Isdoll.INE:
                if (INE_ClipNameAndURL.ContainsKey(ClipName))
                {
                    INE_ClipNameAndURL.Remove(ClipName);
                    int n = INE_URLNameList.FindIndex(0, INE_URLNameList.Count, element => element == ClipName);
                    if (n != -1)
                        INE_URLNameList.RemoveAt(n);
                    else
                        Debug.Log("���� ����Դϴ�.");
                }
                else
                {
                    Debug.LogFormat("{0} Ŭ���� ���� ���� �ʽ��ϴ�.", ClipName);
                }
                break;
            case Utillity.Isdoll.JING:
                if (JING_ClipNameAndURL.ContainsKey(ClipName))
                {
                    JING_ClipNameAndURL.Remove(ClipName);
                    int n = JING_URLNameList.FindIndex(0, JING_URLNameList.Count, element => element == ClipName);
                    if (n != -1)
                        JING_URLNameList.RemoveAt(n);
                    else
                        Debug.Log("���� ����Դϴ�.");
                }
                else
                {
                    Debug.LogFormat("{0} Ŭ���� ���� ���� �ʽ��ϴ�.", ClipName);
                }
                break;
            case Utillity.Isdoll.LiLL:
                if (LIL_ClipNameAndURL.ContainsKey(ClipName))
                {
                    LIL_ClipNameAndURL.Remove(ClipName);
                    int n = LIL_URLNameList.FindIndex(0, LIL_URLNameList.Count, element => element == ClipName);
                    if (n != -1)
                        LIL_URLNameList.RemoveAt(n);
                    else
                        Debug.Log("���� ����Դϴ�.");
                }
                else
                {
                    Debug.LogFormat("{0} Ŭ���� ���� ���� �ʽ��ϴ�.", ClipName);
                }
                break;
            case Utillity.Isdoll.JU:
                if (JU_ClipNameAndURL.ContainsKey(ClipName))
                {
                    JU_ClipNameAndURL.Remove(ClipName);
                    int n = JU_URLNameList.FindIndex(0, JU_URLNameList.Count, element => element == ClipName);
                    if (n != -1)
                        JU_URLNameList.RemoveAt(n);
                    else
                        Debug.Log("���� ����Դϴ�.");
                }
                else
                {
                    Debug.LogFormat("{0} Ŭ���� ���� ���� �ʽ��ϴ�.", ClipName);
                }
                break;
            case Utillity.Isdoll.Go:
                if (GO_ClipNameAndURL.ContainsKey(ClipName))
                {
                    GO_ClipNameAndURL.Remove(ClipName);
                    int n = GO_URLNameList.FindIndex(0, GO_URLNameList.Count, element => element == ClipName);
                    if (n != -1)
                        GO_URLNameList.RemoveAt(n);
                    else
                        Debug.Log("���� ����Դϴ�.");
                }
                else
                {
                    Debug.LogFormat("{0} Ŭ���� ���� ���� �ʽ��ϴ�.", ClipName);
                }
                break;
            case Utillity.Isdoll.VII:
                if (VII_ClipNameAndURL.ContainsKey(ClipName))
                {
                    VII_ClipNameAndURL.Remove(ClipName);
                    int n = VII_URLNameList.FindIndex(0, VII_URLNameList.Count, element => element == ClipName);
                    if (n != -1)
                        VII_URLNameList.RemoveAt(n);
                    else
                        Debug.Log("���� ����Դϴ�.");
                }
                else
                {
                    Debug.LogFormat("{0} Ŭ���� ���� ���� �ʽ��ϴ�.", ClipName);
                }
                break;
        }
    }
    public void ExitBtn()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //�Է� �Լ�
    public void InputButton()
    {
        Instantiate(InputUIWnd, InputUIParent.parent);
    }

}
