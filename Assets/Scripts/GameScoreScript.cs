using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI _maxHeightText;

    void Update()
    {
        _scoreText.text = $"Score: {PlayerPrefs.GetInt("score")}";
        _maxHeightText.text = $"Max height: {PlayerPrefs.GetFloat("height"):F1}";
    }
}
