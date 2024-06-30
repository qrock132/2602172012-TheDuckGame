using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public float currentScore = 0f;

    public bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
        }

        if (Input.GetKeyDown("k"))
        {
            isPlaying = true;
        }
    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
    }
    public void GameOver()
    {
        onGameOver.Invoke();
        currentScore = 0;
        isPlaying = false;
    }

    public string Score()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
