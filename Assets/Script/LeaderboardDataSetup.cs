using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardDataSetup : MonoBehaviour
{

    public TMP_Text playerNameTxt, scoreTxt;
    
    public void Initialize(string _playerName, int _score)
    {
        playerNameTxt.text = _playerName;
        scoreTxt.text = _score.ToString();
    }
}
