using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float timeToMatch = 10f;
    public float currentTimeToMatch = 0;
    public int Points = 0;
    public UnityEvent OnPointsUpdated;
    public UnityEvent<GameState> OnGameStateUpdated;
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

        // Inicializa el estado del juego en Idle
        gameState = GameState.Idle;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void Update()
    {
        if (gameState == GameState.InGame)
        {
            currentTimeToMatch += Time.deltaTime;
            if (currentTimeToMatch > timeToMatch)
            {
                gameState = GameState.GameOver;
                OnGameStateUpdated?.Invoke(gameState);
            }
        }   
    }

    public void AddPoints(int newPoints)
    {
        Points += newPoints;
        OnPointsUpdated?.Invoke();
        currentTimeToMatch = 0;
    }

    public void RestartGame()
    {
        Points = 0;
        gameState = GameState.InGame;
        OnGameStateUpdated?.Invoke(gameState);
        currentTimeToMatch = 0;

    }

    public void StartGame()
    {
        Points = 0;
        gameState = GameState.InGame;
        OnGameStateUpdated?.Invoke(gameState);
        currentTimeToMatch = 0;

    }

    public void ExitGame()
    {
        Points = 0;
        gameState = GameState.Idle;
        OnGameStateUpdated?.Invoke(gameState);
    }
}
