using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPoolManager : MonoBehaviour
{
    [SerializeField] Sprite[] _BG;
    [SerializeField] Sprite[] _ClipImage;
    static DataPoolManager _uniqueIntance;
    public static DataPoolManager _instance
    {
        get
        {
            return _uniqueIntance;
        }
    }
    private void Awake()
    {
        _uniqueIntance = this;
        DontDestroyOnLoad(gameObject);
    }
    public Sprite GetRandomBG()
    {
        int n = Random.Range(0, _BG.Length);
        return _BG[n];
    }
    public Sprite GetClipImage(int eIsedoll)
    {
        return _ClipImage[eIsedoll];
    }

    
    


}