using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Screens")]
    public MainMenuScreen MainMenuScreen;
    public ExampleScreen ExampleScreen;

    private BaseScreen _currentScreen;


    private void Awake()
    {
        Instance = this;

        // Initialize screens safely
        InitializeScreens();
        ShowScreen(MainMenuScreen);
    }

    private void InitializeScreens()
    {
        // Ensure MainMenuScreen and ExampleScreen are not null before hiding them
        if (MainMenuScreen != null)
        {
            MainMenuScreen.Hide();
        }
        else
        {
            Debug.LogError("MainMenuScreen is not assigned in the Inspector!");
        }

        if (ExampleScreen != null)
        {
            ExampleScreen.Hide();
        }
        else
        {
            Debug.LogError("ExampleScreen is not assigned in the Inspector!");
        }
    }

    public void ShowScreen(BaseScreen screen)
    {
        if (_currentScreen != null)
        {
            _currentScreen.Hide();
        }

        _currentScreen = screen;
        _currentScreen.Show();
    }
}

