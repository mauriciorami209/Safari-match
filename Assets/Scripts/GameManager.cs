using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timeToMatch = 10f;
    public float currentTimeToMatch = 0;
    public int Points = 0;
    public UnityEvent OnPointsUpdated;
    public GameState gameState;
    public enum GameState
    {
        Idle,
        InGame,
        GameOver
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (gameState == GameState.InGame)
        {
            currentTimeToMatch += Time.deltaTime;
            if (currentTimeToMatch > timeToMatch)
            {
                gameState = GameState.GameOver;
            }
        }   
    }

    public void AddPoints(int newPoints)
    {
        Points += newPoints;
        OnPointsUpdated?.Invoke();
        currentTimeToMatch = 0;
    }
}
