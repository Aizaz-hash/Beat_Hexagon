using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;


public class PlayFabManager : MonoBehaviour
{

    public GameObject rowPrefab;
    public GameObject LeaderboardPopup;
    public Transform rowsParents;
    public GameObject NamePopup;
    public InputField nameInput;
    void Start()
    {
        LeaderboardPopup.SetActive(false);
        Login();
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
        if (result.InfoResultPayload.PlayerProfile.DisplayName!= null && result.InfoResultPayload.PlayerProfile !=null)
        {
            Debug.Log("Name is not null");
            //NamePopup.SetActive(true);

            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        else if (result.InfoResultPayload.PlayerProfile != null || result.InfoResultPayload.PlayerProfile.DisplayName == null)
        {
            Debug.Log("Name is null");

            NamePopup.SetActive(true);
        }



        Debug.Log("Account Created / Logged In Successfully");
    }


    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text
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

    public void setScore(int score)
    {
        SendLeaderboard(score);
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                   StatisticName = "BeatHexagoneHighscore",
                   Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfully updated score");

    }


    public void GetLeaderBoard()
    {
        Debug.Log("Get Leader BOard");

        var request = new GetLeaderboardRequest
        {
            StatisticName = "BeatHexagoneHighscore",
            StartPosition = 0,
            MaxResultsCount = 10,

        };

        PlayFabClientAPI.GetLeaderboard(request, GetOnLeaderboard, OnError);

    }

    void GetOnLeaderboard(GetLeaderboardResult result)
    {
        //destr
        foreach (Transform item in rowsParents)
        {
            Destroy(item.gameObject);
        }

        //displaying leadeer board on screen
        foreach (var item in result.Leaderboard)
        {

            GameObject newGo = Instantiate(rowPrefab, rowsParents);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName.ToString();
            texts[2].text = item.StatValue.ToString();

        }


    }

    public void activeLeaderBoard()
    {
        LeaderboardPopup.SetActive(true);
    }



}
