using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] Transform Initpos;
    [SerializeField] GameObject ClipPrefab;
    [SerializeField] Transform ClipParent;

    // Start is called before the first frame update
    void Start()
    {
        // 1ȸ �ӽ� ���� Test.
        // ���� ���� 
        GameObject go = Instantiate(ClipPrefab, Initpos.position , Quaternion.identity ,ClipParent);
        LinkObject Lobj = go.GetComponent<LinkObject>();
        string Url = "https://www.twitch.tv/gosegugosegu/clip/AmericanGlamorousGullRiPepperonis-Prrfn3aSrAzZE7pG";
        Lobj.InitSet("�ֳ��� ���� ��������", "EX", Url);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
