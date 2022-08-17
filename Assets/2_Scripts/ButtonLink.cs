using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLink : MonoBehaviour
{
    public void TestURL()
    {
        Application.OpenURL("https://ncube-studio.tistory.com/entry/%EB%B2%84%ED%8A%BC-%ED%81%B4%EB%A6%AD%EC%8B%9C-%EC%9B%B9%EC%82%AC%EC%9D%B4%ED%8A%B8URL-%EC%97%B0%EA%B2%B0-%EC%9B%B9%EB%B8%8C%EB%9D%BC%EC%9A%B0%EC%A0%80-%EB%A7%81%ED%81%AC%EC%9C%A0%EB%8B%88%ED%8B%B0-2D-%EA%B8%B0%EC%B4%88%EA%B0%95%EC%A2%8C-Unity-C-ScriptLink-Web-Browser-ApplicationOpenURL");
    }
    public void NaverURL()
    {
        Application.OpenURL("https://www.naver.com/");
    }
}
