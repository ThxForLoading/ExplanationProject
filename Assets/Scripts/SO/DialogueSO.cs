using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSegment", menuName = "ScriptableObjects/DialogueSegment", order = 1)]
public class DialogueSO : ScriptableObject
{
    public string text;
    public ScriptableObject nextSegment;
}
