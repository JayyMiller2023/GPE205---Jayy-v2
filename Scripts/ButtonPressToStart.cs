using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ButtonPressToStart : MonoBehaviour
{
    public void ChangeToMainMenu()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateMainMenuScreen();
        }
    }

    public void ChangeToOptions()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateOptionsScreen();
        }
    }

    public void ChangeToCredits()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateCreditsScreen();
        }
    }

    public void ChangeToGameplay()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateGameplay();
        }
    }
}
