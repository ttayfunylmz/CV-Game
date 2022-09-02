using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] sentences;
    [SerializeField] private float typeSpeed;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject startPlayingButton;
    [SerializeField] private AudioSource keyboardSounds;

    private int index;

    private void Start() 
    {        
        StartCoroutine(Type());
        keyboardSounds.Play();
    }

    private void Update() 
    {
        if(dialogueText.text == sentences[index])
        {
            continueButton.SetActive(true);
            keyboardSounds.Stop();
        }
    }

    private IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed); 
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Type());
            keyboardSounds.Play();
        }
        else
        {
            dialogueText.text = "";
            continueButton.SetActive(false);
            startPlayingButton.SetActive(true);
        }
    }
}
