using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExampleScreen : BaseScreen
{
    public TextMeshProUGUI TextLabel;
    
    public override void Show()
    {
        base.Show();

        TextLabel.text = "Example";
    }
    
    public void OnBackClicked()
    {
        UIManager.Instance.ShowScreen(UIManager.Instance.MainMenuScreen);
    }
}
