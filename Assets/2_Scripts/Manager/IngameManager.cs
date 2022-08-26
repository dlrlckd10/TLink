using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    List<Dictionary<string, string>> KindClipList = new List<Dictionary<string, string>>();
    
    public Dictionary<string, string> URLAndStatusDic = new Dictionary<string, string>();


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
        
        
        //URLAndStatusDic[Url] = ClipEx;
        //KindClipList[Isdollnum].Add(ClipName);
        //
    }

    public void AddTLink(int KindClip)
    {
        //Test
        //KindClipList[KindClip] = URLAndStatusDic;
        KindClipList.Add(URLAndStatusDic);
        for(int n = 0; n <KindClipList.Count;n++)
        {
            //Debug.Log("Test 1 : " + KindClipList[n].Keys + KindClipList[n].Values.ToString());
            //Debug.Log("Test 2 : " + KindClipList[n]);
            //Debug.Log("Test 3 : " + KindClipList.Count);
            //Debug.Log("Test 4 : " + KindClipList[n].Keys.Count);

            foreach(KeyValuePair<string , string > pair in KindClipList[n])
            {
                Debug.Log("Clip Name : " + pair.Key + "Clip URL : " + pair.Value);
            }
           
        }

        //


    }

    //void DataSave(int num , )

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputButton()
    {
        Instantiate(InputUIWnd, gameObject.transform.parent);
    }
}
