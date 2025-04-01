using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuScreen : BaseScreen
{
    public TextMeshProUGUI TextLabel;

    public override void Show()
    {
        base.Show();
    }

    public void OnExampleClicked()
    {
        UIManager.Instance.ShowScreen(UIManager.Instance.ExampleScreen);
    }
}
