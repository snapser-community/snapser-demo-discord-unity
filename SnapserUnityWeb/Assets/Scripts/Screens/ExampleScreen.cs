using System;
using TMPro;
using UnityEngine;
//using static Dissonity.Api;
using Snapser.Api;
using Snapser.Client;
using Snapser.Model;

public class ExampleScreen : BaseScreen
{
    public TextMeshProUGUI TextLabel;

    private const string discordId = "1354572144436183261";
    private Configuration _snapserConfig;

    private void Awake()
    {
        Configuration config = new Configuration();
#if DISCORD_BUILD
#if UNITY_EDITOR
        // Assuming you might want to log or do something specific when in Editor for Discord build
        Debug.Log("Using the Discord build in Editor");
#else
            // string discordAddress = $"{uri.Scheme}://{clientId}.discordsays.com/.proxy/{domain}/{subdomain}{uri.path}";
            // string currentBasePath = config.BasePath;
            // Uri uri = new Uri(currentBasePath);
            config.BasePath = string.Format("https://{0}.discordsays.com/.proxy/", discordId);
            Debug.Log("Using the Discord build in Production");
            Debug.Log("Snapser URL via Discord is: " + config.BasePath);
#endif
#else
        Debug.Log("Not using the Discord build");
#endif
        _snapserConfig = config;
    }

    async void Start()
    {
        // Initialize the Snapser API client
        var apiInstance = new AuthServiceApi(_snapserConfig);
        var anonLoginRequest = new AuthAnonLoginRequest(createUser: true, username: "12345");

        try
        {
            // Anonymous Login
            AuthAnonLoginResponse result = await apiInstance.AnonLoginAsync(anonLoginRequest);
            Debug.Log(result.User.Id);
            TextLabel.text = result.User.Id;
            Debug.Log("Done!");
        }
        catch (ApiException e)
        {
            Debug.LogError("Exception when calling AuthServiceApi.AnonLogin: " + e.Message);
            Debug.LogError("Status Code: " + e.ErrorCode);
            Debug.LogError(e.StackTrace);
            TextLabel.text = "Unable to login";
        }
    }


    public override void Show()
    {
        base.Show();
    }

    public void OnBackClicked()
    {
        UIManager.Instance.ShowScreen(UIManager.Instance.MainMenuScreen);
    }
}
