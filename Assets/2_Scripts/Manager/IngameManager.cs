using System.Collections.Generic;
using UnityEngine;
//
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
    //����ý��� ���
    // 1. Load�ؼ� ������ ���� �� �ִ� �� ����.
    // 1.5 ������ �����Ѵٸ� -> Load 
    // 
    // 1.5 ������ �������� �ʴ´ٸ� -> �Է� ���� ���� Dic�� ���� �� Json���Ϸ� �����Ѵ�.
    //
    // 2. ���� ����
    // Dic���� Ŭ�� �̸� (key) , Ŭ�� URL (Value)
    // key - �о���� ���.
    // �� Json���Ͽ� ��� ���̼����� �߰�ȣ �ȿ� ���� �����Ѵ�.
    // Load�� �� List�� ������� �����Ѵ�.
    //
    // 3. ���ο� Ŭ���� ����Ǹ� Save �� �ٽ��ϸ� ,
    // �ٽ� �о�´�(Load)


    [SerializeField] Transform Initpos;
    [SerializeField] GameObject ClipPrefab;
    [SerializeField] Transform ClipParent;
    [SerializeField] GameObject InputUIWnd;

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
    public Dictionary<string, string> Ju_ClipNameAndURL = new Dictionary<string, string>();
    public List<string> JU_URLNameList = new List<string>();
    //Go
    public Dictionary<string, string> GO_ClipNameAndURL = new Dictionary<string, string>();
    public List<string> GO_URLNameList = new List<string>();
    //VII
    public Dictionary<string, string> VII_ClipNameAndURL = new Dictionary<string, string>();
    public List<string> VII_URLNameList = new List<string>();


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _uniqueInstance = this;
    }

    void Start()
    {



        //���� Test
        TextAsset DictextAsset = Resources.Load("GoseguDic") as TextAsset;
        TextAsset ListtextAsset = Resources.Load("GoseguList") as TextAsset;
        if (DictextAsset != null || ListtextAsset != null)
        {
            Debug.Log("���� ���� - Load !");
            JsonLoad(DictextAsset.text, ListtextAsset.text);
        }
        else
        {
            Debug.Log("���� ���� - Load ����!");
        }

        //
    }

    // Load -> ������ ������ ���翩�θ� Ȯ���Ѵ�.
    // ������ ������ ������ �ڷ� ������ �����Ѵ�.
    // ���ο� List�� ������ ���� ����� ��ó�� �����Ѵ�. - List�� Dic�� ���ڰ� 0�� �׸��� �������� �ʴ´�.



    // 
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
                Ju_ClipNameAndURL.Add(ClipName, ClipURL);
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
    }

    //���� Test
    public void SaveIsdolClip(Utillity.Isdoll eisdoll)
    {
        
        switch (eisdoll)
        {
            case Utillity.Isdoll.INE:
                break;
            case Utillity.Isdoll.JING:
                break;
            case Utillity.Isdoll.LiLL:
                break;
            case Utillity.Isdoll.JU:
                break;
            case Utillity.Isdoll.Go:
                //����
                {
                    //Dic ����
                    string fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "GoseguDic" + ".Json";
                    StreamWriter fileWrite = new StreamWriter(fullpath, false,Encoding.Unicode);
                    SaveJsonDic("GoseguDic", fullpath, GO_ClipNameAndURL, fileWrite);
                    fileWrite.Close();
                    //
                    //Ket List����
                    fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "GoseguList" + ".Json";
                    fileWrite = new StreamWriter(fullpath, false, Encoding.Unicode);
                    SaveJsonList("GoseguList", fullpath , GO_URLNameList, fileWrite);
                    fileWrite.Close();
                    //
                }
                break;
            case Utillity.Isdoll.VII:
                break;
        }
    }
    // Test
    public void ResetBtn()
    {
        // 1ȸ �ӽ� ���� Test.
        Vector3 DistancPos = Initpos.position;
        //���� ������ ���� ���°� �ƴ϶� Load�� 0
        for (int n = 0; n < GO_ClipNameAndURL.Count; n++)
        {
            GameObject go = Instantiate(ClipPrefab, DistancPos, Quaternion.identity, ClipParent);
            LinkObject Lobj = go.GetComponent<LinkObject>();
            int Isdollnum = (int)Utillity.Isdoll.Go;
            string ClipName = GO_URLNameList[n].ToString();
            string Url = GO_ClipNameAndURL[GO_URLNameList[n].ToString()];
            Lobj.InitSet(Isdollnum, ClipName, Url);
            DistancPos += new Vector3(0f, -200f, 0f);

        }
    }

    void JsonLoad(string Dictxt , string Listtxt)
    {
        // ������ LoadTest
        // List ����
        JsonData mydata = JsonMapper.ToObject(Listtxt);
        GO_URLNameList.Clear();
        GO_ClipNameAndURL.Clear();
        for (int n = 0; n < mydata[0][0].Count; n++)
        {
            GO_URLNameList.Add(mydata[0][0][n].ToString());
        }
        //
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


    public void ExitBtn()
    {
        // �����ư
    }

    //�Է� �Լ�
    public void InputButton()
    {
        Instantiate(InputUIWnd, gameObject.transform.parent);
    }
}
