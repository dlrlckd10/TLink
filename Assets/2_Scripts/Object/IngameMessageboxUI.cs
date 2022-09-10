using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class IngameMessageboxUI : MonoBehaviour
{
    public static IngameMessageboxUI _uniqueInstance;
    public static IngameMessageboxUI _instance
    {
        get { return _uniqueInstance; }
    }



    Text msgBoxtxt;
    void Awake()
    {
        gameObject.SetActive(false);
        _uniqueInstance = this;
        GameObject go = transform.GetChild(0).gameObject;
        msgBoxtxt = go.GetComponent<Text>();
    }

    public void IngameMessageTxt(string str)
    {
        gameObject.SetActive(true);
        msgBoxtxt.text = str;
        StartCoroutine(DelayCoroutine());

    }
    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        yield return null;
    }
}
