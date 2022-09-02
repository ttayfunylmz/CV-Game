using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoverAudio : MonoBehaviour
{
    [SerializeField] GameObject buttonAudio;

    public void PlayAudio()
    {
        Instantiate(buttonAudio, transform.position, transform.rotation);
    }
}
