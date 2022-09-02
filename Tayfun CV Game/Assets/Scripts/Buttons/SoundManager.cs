using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Image soundOnIcon;
    [SerializeField] private Image soundOffIcon;

    private bool isMuted;

    private void Start() 
    {
        if(!PlayerPrefs.HasKey("isMuted"))
        {
            PlayerPrefs.SetInt("isMuted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = isMuted;
    }

    public void OnButtonPress()
    {
        if(isMuted == false)
        {
            isMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            isMuted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if(isMuted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        isMuted = PlayerPrefs.GetInt("isMuted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
    }

}
