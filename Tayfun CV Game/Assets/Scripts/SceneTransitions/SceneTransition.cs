using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] RectTransform fader;

    private void Start() 
    {
        fader.gameObject.SetActive(true);

        LeanTween.alpha(fader, 1, 0);
        LeanTween.alpha(fader, 0, 0.5f).setOnComplete (() => {
            fader.gameObject.SetActive(false);
        });
    }

    public void LoadCreditsScene()
    {
        fader.gameObject.SetActive(true);

        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete (() => {
            Invoke("Credits", 0.35f);
        });
    }

    public void LoadCVScene()
    {
        fader.gameObject.SetActive(true);

        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete (() => {
            Invoke("CV", 0.35f);
        });
    }

    public void LoadMainMenuScene()
    {
        fader.gameObject.SetActive(true);

        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete (() => {
            Invoke("MainMenu", 0.35f);
        });
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void CV()
    {
        SceneManager.LoadScene("CV");
    }

    private void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
