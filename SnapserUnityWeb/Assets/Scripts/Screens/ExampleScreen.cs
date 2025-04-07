using System;
using TMPro;
using UnityEngine;
using static Dissonity.Api;
using Snapser.Api;
using Snapser.Client;
using Snapser.Model;


public class ExampleScreen : BaseScreen
{
    public TextMeshProUGUI DiscordText;

    public TextMeshProUGUI SnapserText;


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

    // async void Start()
    // {

    // }


    public override void Show()
    {
        base.Show();
    }

    public void OnBackClicked()
    {
        UIManager.Instance.ShowScreen(UIManager.Instance.MainMenuScreen);
    }

    public async void OnAuthenticateClicked()
    {
        if (SnapserText == null || DiscordText == null)
        {
            Debug.LogError("SnapserText or DiscordText is not assigned in the inspector.");
            return;

        }
        SnapserText.text = "";
        if (DiscordText != null)
        {
            DiscordText.text = "Authenticating with Discord...";
        }

        string userId = await GetUserId();
        string userAccessToken = await GetAccessToken();
        Debug.Log($"The user's id is {userId}");
        Debug.Log($"The user's access token is {userAccessToken}");
        // Create a short version of the userId and userAccessToken
        string shortUserId = userId.Length >= 3 ? userId[..3] : userId;
        string shortUserAccessToken = userAccessToken.Length >= 3 ? userAccessToken[..3] : userAccessToken;
        //Set the text
        DiscordText.text = $"Id: {shortUserId}... Token: {shortUserAccessToken}...";

        // Initialize the Snapser API client
        SnapserText.text = "Authenticating with Snapser...";
        var apiInstance = new AuthServiceApi(_snapserConfig);
        var anonLoginRequest = new AuthAnonLoginRequest(createUser: true, username: userId);

        try
        {
            // Anonymous Login
            AuthAnonLoginResponse result = await apiInstance.AnonLoginAsync(anonLoginRequest);
            Debug.Log(result.User.Id);
            SnapserText.text = result.User.Id;
            Debug.Log("Done!");
        }
        catch (ApiException e)
        {
            Debug.LogError("Exception when calling AuthServiceApi.AnonLogin: " + e.Message);
            Debug.LogError("Status Code: " + e.ErrorCode);
            Debug.LogError(e.StackTrace);
            SnapserText.text = "Unable to login";
        }
    }
}

