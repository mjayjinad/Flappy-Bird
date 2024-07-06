using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardData : MonoBehaviour
{

    [Serializable]
    public class ScoreData
    {
        public string playerName;
        public int playerScore;
    }
}
