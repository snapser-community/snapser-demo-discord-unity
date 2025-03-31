using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Dissonity.Api;
using Snapser.Api;
using Snapser.Client;
using Snapser.Model;


public class ExampleScreen : BaseScreen
{
    public TextMeshProUGUI TextLabel;

    async void Start()
    {
        // Show the Discord user id
        string userId = await GetUserId();
        Debug.Log($"The user's id is {userId}");

        SubActivityInstanceParticipantsUpdate((data) =>
        {
            Debug.Log("Received a participants update!");
        });

        // Get an Anonymous user id from Snapser
        Configuration config = new Configuration();
        config.BasePath = "https://gateway-accel.snapser.com/q9n92w7o";
        var apiInstance = new AuthServiceApi(config);
        var anonLoginRequest = new AuthAnonLoginRequest(createUser: true, username: userId);

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
