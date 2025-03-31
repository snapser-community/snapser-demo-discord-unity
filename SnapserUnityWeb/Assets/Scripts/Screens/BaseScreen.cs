using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dissonity.Api;


public abstract class BaseScreen : MonoBehaviour
{
    async void Start()
    {
        string userId = await GetUserId();
        Debug.Log($"The user's id is {userId}");

        SubActivityInstanceParticipantsUpdate((data) =>
        {
            Debug.Log("Received a participants update!");
        });
    }

    public virtual void Show()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
