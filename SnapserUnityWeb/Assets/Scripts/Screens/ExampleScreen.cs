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

        //Get the Discord User Id and the Access token from Snapser Dissonity
        string userId = await GetUserId();
        string userAccessToken = await GetAccessToken();
        Debug.Log($"Discord id is {userId}");
        Debug.Log($"Discord access token is {userAccessToken}");
        // Create a short version of the userId and userAccessToken
        string shortUserId = userId.Length >= 3 ? userId[..3] : userId;
        string shortUserAccessToken = userAccessToken.Length >= 3 ? userAccessToken[..3] : userAccessToken;
        //Set the text
        DiscordText.text = $"Id: {shortUserId}... Token: {shortUserAccessToken}...";

#if DISCORD_BUILD
#if UNITY_EDITOR
        Debug.Log("Using the Discord build in Editor. OnAuthenticateClicked() method.");
#else
        // Initialize the Snapser API client for authenticating with Discord
        SnapserText.text = "Authenticating with Snapser...";
        var apiInstance = new AuthServiceApi(_snapserConfig);
        var discordLoginRequest = new AuthDiscordLoginRequest(accessToken: userAccessToken, code: "", createUser: true);
        try
        {
            AuthDiscordLoginResponse result = await apiInstance.DiscordLoginAsync(discordLoginRequest);
            //You now have a Snapser Identity that is tied to Discord
            //You can now use User.Id and User.SessionToken to hit any other APIs
            Debug.Log($"Snapser id is {result.User.Id}");
            Debug.Log($"Snapser session token is {result.User.SessionToken}");
            SnapserText.text = result.User.Id;
            Debug.Log("Done!");
        }
        catch (ApiException e)
        {
            Debug.LogError("Exception when calling AuthServiceApi.DiscordLogin: " + e.Message);
            Debug.LogError("Status Code: " + e.ErrorCode);
            Debug.LogError(e.StackTrace);
            SnapserText.text = "Unable to login";
        }
#endif
#else
        Debug.Log("Not using the Discord build. OnAuthenticateClicked() method.");
#endif
    }

}

