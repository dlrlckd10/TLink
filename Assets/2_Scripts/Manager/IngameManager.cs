using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] Transform Initpos;
    [SerializeField] GameObject ClipPrefab;
    [SerializeField] Transform ClipParent;

    //������ ����. List[(int)INE]<Dictionary>>
    //             ClipName           URL , StatusString
    List<Dictionary<string, Dictionary<string, string>>> KindClipList = new List<Dictionary<string, Dictionary<string, string>>>();
    Dictionary<string, string> URLAndStatusDic = new Dictionary<string, string>(); 
    // Start is called before the first frame update
    void Start()
    {
        // 1ȸ �ӽ� ���� Test.
        GameObject go = Instantiate(ClipPrefab, Initpos.position , Quaternion.identity ,ClipParent);
        LinkObject Lobj = go.GetComponent<LinkObject>();
        string Url = "https://www.twitch.tv/gosegugosegu/clip/AmericanGlamorousGullRiPepperonis-Prrfn3aSrAzZE7pG";
        string ClipName = "�ֳ��� ���� ��������";
        string ClipEx = "EX";
        int Isdollnum = 0;
        //Test
        Lobj.InitSet(Isdollnum,ClipName, ClipEx, Url);
        
        
        //URLAndStatusDic[Url] = ClipEx;
        //KindClipList[Isdollnum].Add(ClipName);
        //
    }

    //void DataSave(int num , )

    // Update is called once per frame
    void Update()
    {
        
    }
}
