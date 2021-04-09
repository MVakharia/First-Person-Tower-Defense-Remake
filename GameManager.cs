using UnityEngine;

public enum GameState
{
    Build, Assault
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameState currentGameState;

    public GameState CurrentGameState => currentGameState;

    public bool IsInBuildPhase => currentGameState == GameState.Build;

    public bool IsInAssaultPhase => currentGameState == GameState.Assault;

    private static GameManager singleton;

    public static GameManager Singleton
    {
        get
        {
            if(singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();                    
            }
            return singleton;
        }
    }

    private void GoToBuildPhase() => currentGameState = GameState.Build;

    public void GoToAssaultPhase() => currentGameState = GameState.Assault;

    public void Start()
    {
        GoToBuildPhase();
    }
}