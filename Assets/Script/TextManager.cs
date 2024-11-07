using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PixelCrushers.DialogueSystem;
using Febucci.UI;
using Febucci.UI.Core;
using static UnityEditor.VersionControl.Asset;

public class TextManager : MonoBehaviour
{
    private TMP_Text mainText;
    private TAnimCore animCore;
    private TypewriterCore writer;
    [SerializeField, TextArea(1, 5)] string[] dialoguesLines;


    int dialogueIndex = 0;
    int dialogueLength;
    
    // Start is called before the first frame update
    void Start()
    {
        mainText = GetComponent<TMP_Text>();
        animCore = GetComponent<TAnimCore>();
        writer = GetComponent<TypewriterCore>();  
        dialogueIndex = 0;
    }

    void Awake()
    {
        dialogueLength = dialoguesLines.Length;
    }

    void ContinueSequence()
    {
        dialogueIndex++;
        if (dialogueIndex < dialogueLength)
        {
            writer.ShowText(dialoguesLines[dialogueIndex]);
        }
        else
        {
            writer.StartDisappearingText();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueSequence();
        }
    }
}
