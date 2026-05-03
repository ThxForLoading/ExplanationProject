using TMPro;
using UnityEngine;

public class Array : MonoBehaviour
{
    [SerializeField] GameObject[] arraySlots;
    [SerializeField] TMP_Text[] arrayText;
    [SerializeField] int[] arrayValues = new int[8];
    int index = 0;
    [SerializeField] TMP_Text indexText;
    [SerializeField] TMP_Text outputText;
    [SerializeField] GameObject error;
    [SerializeField] Material green;
    [SerializeField] Material black;
    [SerializeField] Material red;
    [SerializeField] bool preventError = true;

    void Start()
    {
        foreach(var slot in arraySlots)
        {
            slot.gameObject.GetComponent<MeshRenderer>().material = black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        indexText.text = index.ToString();
        if((index < arrayValues.Length && index > 0) || !preventError)
        {
            outputText.text = arrayValues[index].ToString();
        }
        

        for (int i = 0; i < arrayText.Length; i++)
        {
            arrayText[i].text = arrayValues[i].ToString();
        }

        for (int i = 0; i < arraySlots.Length; i++)
        {
            if(i ==  index) arraySlots[i].gameObject.GetComponent<MeshRenderer>().material = green;
            else arraySlots[i].GetComponent<MeshRenderer>().material = black;
        }

        if(index < 0 || index >= arraySlots.Length)
        {
            error.GetComponent<MeshRenderer>().material = red;
        }
        else
        {
            error.GetComponent<MeshRenderer>().material = black;
        }
    }

    public void IncrementIndex()
    {
        index++;
    }

    public void DecrementIndex()
    {
        index--;
    }
}
