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
        
        //messy
        MainMenuScreen.Hide();
        ExampleScreen.Hide();
        
        ShowScreen(MainMenuScreen);
    }
    
    public void ShowScreen(BaseScreen screen)
    {
        if(_currentScreen != null)
        {
            _currentScreen.Hide();
        }

        _currentScreen = screen;
        _currentScreen.Show();
    }
}

