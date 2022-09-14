using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    public ScrollRect scrollRect;
    public List<RectTransform> UIList = new List<RectTransform>();
    float InitSize_Y;
    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        InitSize_Y = scrollRect.content.sizeDelta.y;
    }

    // 초기 칸 리셋 설정
    public void ResetSpace()
    {
        scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, InitSize_Y);
        UIList.Clear();
    
    }
    // 클립 생성 및 클립 위치 및 클립 창 크기 설정.
    public void AddSpace(GameObject UIPrefab ,int KindNum , string ClipName , string URL ,float Add_y)
    {
        GameObject go = Instantiate(UIPrefab, scrollRect.content);
        LinkObject Lobj = go.GetComponent<LinkObject>();
        Lobj.InitSet(KindNum, ClipName, URL);
        UIList.Add(go.GetComponent<RectTransform>());
        float y = -200f;
        for (int n = 0; n < UIList.Count; n++)
        {
            UIList[n].anchoredPosition = new Vector2(0f, y);
            y += -UIList[n].sizeDelta.y + Add_y;
        }
        scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, -y);
    }

}
