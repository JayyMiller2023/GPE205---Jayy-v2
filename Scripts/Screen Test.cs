using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTest : MonoBehaviour
{
    public KeyCode ActivateTitleScreenX;
    public KeyCode ActivateMainMenuScreenX;
    public KeyCode ActivateOptionsScreenX;
    public KeyCode ActivateCreditsScreenX;
    public KeyCode ActivateGameplayX;
    public KeyCode ActivateGameOverScreenX;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ActivateTitleScreenX))
        {
            gameManager.ActivateTitleScreen();
        }

        if (Input.GetKeyDown(ActivateMainMenuScreenX))
        {
            gameManager.ActivateMainMenuScreen();
        }

        if (Input.GetKeyDown(ActivateOptionsScreenX))
        {
            gameManager.ActivateOptionsScreen();
        }

        if (Input.GetKeyDown(ActivateCreditsScreenX))
        {
            gameManager.ActivateCreditsScreen();
        }

        if (Input.GetKeyDown(ActivateGameplayX))
        {
            gameManager.ActivateGameplay();
        }

        if (Input.GetKeyDown(ActivateGameOverScreenX))
        {
            gameManager.ActivateGameOverScreen();
        }
    }
}
