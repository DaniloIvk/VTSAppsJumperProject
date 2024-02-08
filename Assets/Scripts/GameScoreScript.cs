using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    void Update()
    {
        _scoreText.text = $"Score: {PlayerPrefs.GetInt("score")}";
    }
}
