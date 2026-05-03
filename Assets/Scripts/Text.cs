using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Text : MonoBehaviour
{
    //For more in depth for the audio part:
    //https://youtu.be/P3FcXHEai_E?si=3CxJ-2s5HvBiP6HT
    //https://youtu.be/ta_L_qoMaqc?si=n59h1ZthIKqOIPzB
    //https://youtu.be/4W57Wy6veUM?si=W1eqLYTXcuPZWozY


    [Header("TextBox")]
    [SerializeField] TMP_Text text;
    [SerializeField] string textToPrint;

    [Header("LetterByLetter")]
    [SerializeField] float delay = 0.1f;
    private string fullText;
    private string currentText = "";

    [Header("Audio")]
    [SerializeField] AudioClip[] dialogueTypingSoundClips;
    [SerializeField] bool playTypingAudio = false;
    [SerializeField] bool stopAudioSource = false;
    [Range(1, 5)]
    [SerializeField] int frequencyLevel = 2;
    [Range(-3f,3f)]
    [SerializeField] float minPitch = 0.5f;
    [Range(-3f, 3f)]
    [SerializeField] float maxPitch = 3f;


    AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        text.text = "";
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            text.text = currentText;
            PlayDialogueSound(i);

            yield return new WaitForSeconds(delay);
        }
    }

    public void PrintTextLetterByLetter()
    {
        fullText = textToPrint;
        text.text = "";
        StartCoroutine(ShowText());
    }

    private void PlayDialogueSound(int currentCharCount)
    {
        if(currentCharCount % frequencyLevel == 0)
        {
            if (stopAudioSource) audioSource.Stop();     //Toggle for no overlap

            if (playTypingAudio)
            {
                int randomIndex = Random.Range(0,dialogueTypingSoundClips.Length);
                AudioClip soundClip = dialogueTypingSoundClips[randomIndex];

                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.PlayOneShot(soundClip);
            }
        }
    }
}
