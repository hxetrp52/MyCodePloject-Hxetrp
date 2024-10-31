using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KoreanTyper;
using TMPro;
using Unity.VisualScripting;

public class TypingTest : MonoBehaviour
{
    public TMP_Text text;
    public GameObject Leetaemin;
    private bool IsOpen = false;
    string Test;
    // Start is called before the first frame update
    void Start()
    {
        Leetaemin.SetActive(false);
        Test = text.text;
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !IsOpen)
        {
            IsOpen = true;
           StartCoroutine(TypingRoutine()); 
        }
    }

    IEnumerator TypingRoutine()
    {
        int typingLength =  Test.GetTypingLength();

        for (int index = 0; index <= typingLength; index++) {
            text.text = Test.Typing(index);
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(1.5f);
        Leetaemin.SetActive(true);
    }

    public void GoGmae()
    {
        Debug.Log("<color=red>씬 이동 됌</color>");
    }
    public void GoSetting()
    {
        Debug.Log("<color=green>세팅 판넬 열림</color>");
    }
}
