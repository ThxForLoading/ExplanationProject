using TMPro;
using UnityEngine;
using System.Collections;

public class TextWriter : MonoBehaviour
{
    public static TextWriter instance;

    [SerializeField] TMP_Text textField;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject answersBox;

    private float delay = 0.1f;
    private string textToPrint;
    private bool isWriting = false;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    public void PrintText(string text)
    {
        dialogueBox.SetActive (true);
        textField.text = "";
        textToPrint = text;
        StartCoroutine(ShowText(text));
    }

    IEnumerator ShowText(string fullText)
    {
        isWriting = true;
        string currentText;
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textField.text = currentText;

            yield return new WaitForSeconds(delay);
        }
        isWriting = false;
    }

    public void SkipPrint()
    {
        if (isWriting)
        {
            StopAllCoroutines();
            textField.text = textToPrint;
            isWriting = false;
        }
    }

    public bool IsWriting()
    {
        return isWriting;
    }


    public void HideTextBox()
    {
        StopAllCoroutines();
        dialogueBox.SetActive(false);
        textField.text = "";
    }
}
