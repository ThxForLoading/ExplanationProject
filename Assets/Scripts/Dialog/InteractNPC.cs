using System;
using UnityEngine;

public class InteractNPC : MonoBehaviour, IInteractible
{
    [SerializeField] string[] dialogueTexts;
    [SerializeField] DialoguePerState[] textsPerState;
    [SerializeField] DialogueSO starterText;

    bool currentlyTalking;

    public void Interact()
    {
        if (currentlyTalking)
        {
            if (TextWriter.instance.IsWriting())
            {
                TextWriter.instance.SkipPrint();
            }
            else
            {
                TextWriter.instance.HideTextBox();
                currentlyTalking = false;
            }
        }
        else
        {
            TextWriter.instance.PrintText(dialogueTexts[0]);
            currentlyTalking = true;
        }
    }
}

enum NPCState
{
    talking,
    finished,
    idle
}

[Serializable]
public struct DialoguePerState
{
    public string text;
    public string state;
}
