using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject directionsMenu;
    public TextMeshProUGUI infoText;
    public static MainMenuController Instance;

    private bool isMainMenuOpen = false;
    private bool isDirectionsMenuOpened = false;
    private bool isTextVisible = false;

    public string currentDirection;

    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        ColorManager.BlockScanned += ClearInfoText;
    }

    public void InformationButtonPressed()
    {
        //dont know if needed
        ToggleMainMenu();
    }

    public void ToggleMainMenu()
    {
        if (isTextVisible)
        { ToggleInfoText(); }
        if(isDirectionsMenuOpened)
        {
            TurnOffDirectionsMenu();
        }
        isMainMenuOpen = !isMainMenuOpen;
        mainMenu.SetActive(isMainMenuOpen);
    }
    public void ToggleDirectionsMenu()
    {
        ToggleMainMenu();
        isDirectionsMenuOpened = !isDirectionsMenuOpened;
        directionsMenu.SetActive(isDirectionsMenuOpened);
    }
    public void TurnOffDirectionsMenu()
    {
        isDirectionsMenuOpened = false;
        directionsMenu.SetActive(isDirectionsMenuOpened);
    }
    public void DirectionButtonPressed(string direction)
    {
        infoText.text = "Please locate a focus point";
        currentDirection = direction;
        TurnOffDirectionsMenu();
        ToggleInfoText();
    }

    public void ClearInfoText(CurrentLocations currentLocation)
    {
      infoText.text = "";
      if (currentDirection.Equals("Canteen"))
      {
          MainManager.Instance.OnToCanteenClicked(currentLocation);
      }
      //do something with ${ locations } and ${ currentDirection }
    }
    public void ExitApp()
    {
        Application.Quit();
    }

    public void ToggleInfoText()
    {
        isTextVisible = !isTextVisible;
        infoText.enabled = isTextVisible;
    }

}