using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;


public class NameInput : MonoBehaviour
{

    public GameObject Popup;
    public InputField inputText;
    // Start is called before the first frame update
    void Start()
    {
        Login();
        Popup.SetActive(false);
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }


    void OnSuccess(LoginResult result)
    {
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        {
            Debug.Log("Name is not null");

            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        if (name == null)
        {
            Debug.Log("Name is null");
            Popup.SetActive(true);
        }


        Debug.Log("Account Created / Logged In Successfully");
    }


    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = inputText.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayUpdateName, OnError);
    }

    void OnDisplayUpdateName(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Update Username Successfully");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Erorr while creating Account ");
        Debug.Log(error.GenerateErrorReport());
    }
}
