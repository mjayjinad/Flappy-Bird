using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;
using System.Net.Sockets;

[Serializable]
public class ScoreEntry
{
    public string PlayerName;
    public int Score;
}

public class PlayerScoreData : MonoBehaviour
{
    public string userName;
    public Text score;
    public Button backBtn;
    public GameObject playerDataObject, UI;
    public Transform parent;
    private string apiUrl = "https://localhost:7133/api/Scores";
    public List <LeaderboardData.ScoreData> leaderboard = new List<LeaderboardData.ScoreData>();

    private void Start()
    {
        userName = PlayerPrefs.GetString("name");

        backBtn.onClick.AddListener(() => CloseUI());
    }

    private void CloseUI()
    {
        UI.SetActive(false);
    }

    private void LoadLeaderboardUI()
    {
        for (int i = 0; i < leaderboard.Count; i++)
        {
            GameObject playerData;
            playerData = Instantiate(playerDataObject, parent);

            playerData.GetComponent<LeaderboardDataSetup>().Initialize(leaderboard[i].playerName, leaderboard[i].playerScore);
        }
    }

    public void CallPostScore()
    {
        ScoreEntry newScore = new ScoreEntry
        { PlayerName = userName, Score = int.Parse(score.text) };

        int playerScore = int.Parse(score.text);

        StartCoroutine(PostNewScore(apiUrl, newScore));
       // StartCoroutine(SendScore(apiUrl, playerScore, userName));
    }

    IEnumerator PostNewScore(string url, ScoreEntry scoreEntry)
    {
        string jsonData = JsonUtility.ToJson(scoreEntry);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        UnityWebRequest request = new UnityWebRequest(url, "POST")
        {
            uploadHandler = new UploadHandlerRaw(jsonToSend),
            downloadHandler = new DownloadHandlerBuffer()
        };
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log("Score posted successfully!");

            StartCoroutine(GetLeaderboardScore(apiUrl));
        }
    }

    private IEnumerator SendScore(string apiURL, int _scores, string _playername)
    {
        WWWForm form = new WWWForm();
        form.AddField("score", _scores);
        form.AddField("playerName", _playername);
        using (UnityWebRequest request = UnityWebRequest.Post(apiURL, form))
        {
            //request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log("Score posted successfully!");
            }
        }
    }

    private IEnumerator GetLeaderboardScore(string apiURL)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiURL))
        {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
                Debug.Log(request.downloadHandler.text);
            }
            else
            {
                Debug.Log("Leaderboard request complete!");
                Debug.Log(request.downloadHandler.text);

                JSONNode jsondata = JSON.Parse(request.downloadHandler.text);
                leaderboard.Clear();

                for (int i = 0; i < jsondata.Count; i++)
                {
                    LeaderboardData.ScoreData playerData = new LeaderboardData.ScoreData();
                    playerData.playerName = jsondata[i]["playerName"];
                    playerData.playerScore = jsondata[i]["score"];

                    leaderboard.Add(playerData);
                }

                if(jsondata.Count > 0)
                {
                    LoadLeaderboardUI();
                }
            }
        }
    }
}