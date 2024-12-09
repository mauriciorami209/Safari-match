using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIPoints : MonoBehaviour
{
    int displayetPoints = 0;
    public TextMeshProUGUI pointsLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnPointsUpdated.AddListener(UpdatePoints);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    public void OnDestroy()
    {
        GameManager.Instance.OnPointsUpdated.RemoveListener(UpdatePoints);
        GameManager.Instance.OnGameStateUpdated.RemoveListener(GameStateUpdated);

    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        if(newState == GameManager.GameState.GameOver)
        {
            displayetPoints = 0;
            pointsLabel.text = displayetPoints.ToString();
        }

    }

    void UpdatePoints()
    {
        StartCoroutine(UpdatePointsCoroutine());
    }
    IEnumerator UpdatePointsCoroutine()
    {
        while(displayetPoints < GameManager.Instance.Points)
        {
            displayetPoints++;
            pointsLabel.text = displayetPoints.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

   
}
