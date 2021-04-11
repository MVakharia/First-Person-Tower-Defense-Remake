using UnityEngine;
using TMPro;

public enum GameState
{
    Build, Assault
}

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager singleton;
    public static GameManager Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
            }
            return singleton;
        }
    }
    #endregion

    #region Fields
    [SerializeField]
    private GameState currentGameState;
    [SerializeField]
    private int enemiesThisRound;
    [SerializeField]
    private int enemiesRemainingThisRound;
    [SerializeField]
    private int currentLevel;
    [SerializeField]
    private TMP_Text currentPhaseText;

    #endregion

    #region Properties
    public GameState CurrentGameState => currentGameState;
    public bool IsInBuildPhase => currentGameState == GameState.Build;
    public bool IsInAssaultPhase => currentGameState == GameState.Assault;
    #endregion

    #region Methods
    private void GoToBuildPhase() => currentGameState = GameState.Build;
    private void GoToAssaultPhase() => currentGameState = GameState.Assault;
    private void IncreaseLevel() => currentLevel++;

    public void StartRound ()
    {        
        GoToAssaultPhase();
    }

    #endregion

    public void Start()
    {
        GoToBuildPhase();
    }

    public void Update()
    {
        
    }
}