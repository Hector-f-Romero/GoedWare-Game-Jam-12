using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class GivePointsEvent : UnityEvent<int> { }

public class ScoreManager : MonoBehaviour
{
    [Header("Logic")]
    [SerializeField] private int _playerScore = 0;
    [SerializeField] private float _timeAlive = 0f;
    private string elapsedFormatTime;
    public AudioManager audioManager;

    [Space(10)]
    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timeAliveText;

    // Update is called once per frame
    void Update()
    {
        HandleAliveTime();
            
    }

    [ContextMenu("Increase score")]
    void IncreaseScoreInspector()
    {
        IncreaseScore();
    }

    public void IncreaseScore(int points = 10)
    {
        audioManager.PlaySFX(2);
        _playerScore += points;
        _scoreText.text = _playerScore.ToString();
    }

    void HandleAliveTime()
    {
        _timeAlive += Time.deltaTime;

        int minutes = Mathf.FloorToInt(_timeAlive / 60);
        int seconds = Mathf.FloorToInt(_timeAlive % 60);

        elapsedFormatTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        _timeAliveText.text = elapsedFormatTime;
    }
}
