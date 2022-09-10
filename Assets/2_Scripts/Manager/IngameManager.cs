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
    //저장시스템 방식
    // 1. Load해서 파일을 읽을 수 있는 지 조사.
    // 1.5 파일이 존재한다면 -> Load 
    // 
    // 1.5 파일이 존재하지 않는다면 -> 입력 받은 것을 Dic에 저장 후 Json파일로 저장한다.
    //
    // 2. 파일 구성
    // Dic구성 클립 이름 (key) , 클립 URL (Value)
    // key - 읽어오는 방법.
    // 한 Json파일에 멤버 나이순으로 중괄호 안에 각각 저장한다.
    // Load할 때 List에 순서대로 저장한다.
    //
    // 3. 새로운 클립이 저장되면 Save 를 다시하며 ,
    // 다시 읽어온다(Load)


    [SerializeField] Transform Initpos;
    [SerializeField] GameObject ClipPrefab;
    [SerializeField] Transform ClipParent;
    [SerializeField] GameObject InputUIWnd;

    //public ScrollRect uiScrollRect;

    // Key : URL Name - List로 따로 또 저장한다. / Value : URL 링크
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



        //고세구 Test
        TextAsset DictextAsset = Resources.Load("GoseguDic") as TextAsset;
        TextAsset ListtextAsset = Resources.Load("GoseguList") as TextAsset;
        if (DictextAsset != null || ListtextAsset != null)
        {
            Debug.Log("고세구 파일 - Load !");
            JsonLoad(DictextAsset.text, ListtextAsset.text);
        }
        else
        {
            Debug.Log("고세구 파일 - Load 실패!");
        }

        //
    }

    // Load -> 각각의 파일의 존재여부를 확인한다.
    // 파일이 있으면 각각의 자료 구조에 저장한다.
    // 새로운 List를 저장할 때는 덮어쓰는 것처럼 저장한다. - List와 Dic의 숫자가 0인 항목은 저장하지 않는다.



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

    //저장 Test
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
                //저장
                {
                    //Dic 저장
                    string fullpath = Application.dataPath + "\\" + "Resources" + "\\" + "GoseguDic" + ".Json";
                    StreamWriter fileWrite = new StreamWriter(fullpath, false,Encoding.Unicode);
                    SaveJsonDic("GoseguDic", fullpath, GO_ClipNameAndURL, fileWrite);
                    fileWrite.Close();
                    //
                    //Ket List저장
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
        // 1회 임시 생성 Test.
        Vector3 DistancPos = Initpos.position;
        //현재 파일을 읽은 상태가 아니라서 Load가 0
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
        // 세구만 LoadTest
        // List 먼저
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

    // Dic - Json저장 함수.
    void SaveJsonDic(string Filename , string path, Dictionary<string, string> Dic, StreamWriter streamWt)
    {
        JsonWriter jsonWriter = new JsonWriter(streamWt);
        jsonWriter.WriteObjectStart(); //전체 중괄호 열기
        jsonWriter.WritePropertyName(Filename);
        jsonWriter.WriteArrayStart();// 전체 대괄호 열기
        //내용작성.
        jsonWriter.WriteObjectStart();//필드 괄호.
        foreach (KeyValuePair<string, string> test in Dic)
        {
            jsonWriter.WritePropertyName(test.Key.ToString());
            jsonWriter.Write(test.Value.ToString());
        }
        jsonWriter.WriteObjectEnd(); // 필드괄호 닫기.
        jsonWriter.WriteArrayEnd(); // 전체 대괄호 닫기
        jsonWriter.WriteObjectEnd(); // 전체 중괄호 닫기.
    }
    // List - Json 저장 함수.
    void SaveJsonList(string Filename , string path, List<string> list, StreamWriter streamWt)
    {
        JsonWriter jsonWriter = new JsonWriter(streamWt);
        jsonWriter.WriteObjectStart(); //전체 중괄호 열기
        jsonWriter.WritePropertyName(Filename);
        jsonWriter.WriteArrayStart();// 전체 대괄호 열기
        //내용작성.
        jsonWriter.WriteObjectStart();//필드 괄호.
        //List 저장.
        for (int n = 0; n < list.Count; n++)
        {
            jsonWriter.WritePropertyName(n.ToString());
            jsonWriter.Write(list[n].ToString());
        }
        //
        jsonWriter.WriteObjectEnd(); // 필드괄호 닫기.
        jsonWriter.WriteArrayEnd(); // 전체 대괄호 닫기
        jsonWriter.WriteObjectEnd(); // 전체 중괄호 닫기.
    }


    public void ExitBtn()
    {
        // 종료버튼
    }

    //입력 함수
    public void InputButton()
    {
        Instantiate(InputUIWnd, gameObject.transform.parent);
    }
}
