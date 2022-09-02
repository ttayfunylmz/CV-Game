using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private TMP_Text creditsText;

    [TextArea(15,15)]
    [SerializeField] private string[] sentences;

    [SerializeField] private float typeSpeed;
    [SerializeField] private AudioSource keyboardSounds;

    private int index;

    private void Start() 
    {        
        StartCoroutine(Type());
        keyboardSounds.Play();
    }

    private void Update() 
    {
        if(creditsText.text == sentences[index])
        {

            keyboardSounds.Stop();
        }

        if(index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(Type());
            keyboardSounds.Play();
        }
    }

    private IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            creditsText.text += letter;
            yield return new WaitForSeconds(typeSpeed); 
        }
    }
}
