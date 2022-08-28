using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
using System.Runtime.Serialization.Json;
using System.IO;
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
    [SerializeField] GameObject InputUIWnd;
    
    //public ScrollRect uiScrollRect;

    //데이터 저장. List[(int)INE]<Dictionary>>
    //             ClipName           URL , StatusString
    public List<Dictionary<string, string>> KindClipList = new List<Dictionary<string, string>>();
    
    public Dictionary<string, string> INE_ClipURLAndStatusDic = new Dictionary<string, string>();
    public Dictionary<string, string> JING_ClipURLAndStatusDic = new Dictionary<string, string>();
    public Dictionary<string, string> LIL_ClipURLAndStatusDic = new Dictionary<string, string>();
    public Dictionary<string, string> Ju_ClipURLAndStatusDic = new Dictionary<string, string>();
    public Dictionary<string, string> GO_ClipURLAndStatusDic = new Dictionary<string, string>();
    public Dictionary<string, string> VII_ClipURLAndStatusDic = new Dictionary<string, string>();


    // Xml로 전체 파싱해서 

    // Start is called before the first frame update
    private void Awake()
    {
        _uniqueInstance = this;
    }

    void Start()
    {

        // 1회 임시 생성 Test.
        GameObject go = Instantiate(ClipPrefab, Initpos.position, Quaternion.identity ,ClipParent);
        LinkObject Lobj = go.GetComponent<LinkObject>();
       
        string Url = "https://www.twitch.tv/gosegugosegu/clip/AmericanGlamorousGullRiPepperonis-Prrfn3aSrAzZE7pG";
        string ClipName = "주냥이 보는 세구세구";
        string ClipEx = "EX";
        int Isdollnum = 0;
        //Test
        Lobj.InitSet(Isdollnum,ClipName, ClipEx, Url);
        //DataContractJsonSerializer serilizer = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
        

    }

    // 
    public void AddTLink(int KindClip , string ClipName , string ClipURL)
    {
        switch(KindClip)
        {
            case 0:
                INE_ClipURLAndStatusDic.Add(ClipName, ClipURL);

                break;
            case 1:
                JING_ClipURLAndStatusDic.Add(ClipName, ClipURL);
                break;
            case 2:
                LIL_ClipURLAndStatusDic.Add(ClipName, ClipURL);
                break;
            case 3:
                Ju_ClipURLAndStatusDic.Add(ClipName, ClipURL);
                break;
            case 4:
                GO_ClipURLAndStatusDic.Add(ClipName, ClipURL);
                break;
            case 5:
                VII_ClipURLAndStatusDic.Add(ClipName, ClipURL);
                break;
        }
        //foreach (KeyValuePair<string, string> pair in INE_ClipURLAndStatusDic)
        //{
        //    Debug.Log("Clip Name : " + pair.Key + "Clip URL : " + pair.Value);
        //}
    }

    void SaveTest()
    {
        foreach(KeyValuePair<string , string> temp in INE_ClipURLAndStatusDic)
        {

        }
    }


    //입력 함수
    public void InputButton()
    {
        Instantiate(InputUIWnd, gameObject.transform.parent);
    }
}
