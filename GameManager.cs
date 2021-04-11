using UnityEngine;
using TMPro;
using System.Collections;
public enum TowerDefensePhase { Build, Assault }

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
    private TowerDefensePhase currentPhase;
    [SerializeField]
    private TMP_Text currentPhaseText;

    [SerializeField]
    private TMP_Text enemiesHeaderText;

    [SerializeField]
    private int enemiesThisRound;

    public int EnemiesThisRound => enemiesThisRound;

    [SerializeField]
    private int EnemiesRemainingThisRound => EnemyManager.Singleton.EnemiesRemainingThisRound;

    [SerializeField]
    private TMP_Text enemiesCounterText;

    [SerializeField]
    private int currentLevel;

    [SerializeField]
    private EnemyManager enemyManager;

    #endregion

    #region Properties
    public TowerDefensePhase CurrentGameState => currentPhase;
    public bool IsInBuildPhase => currentPhase == TowerDefensePhase.Build;
    public bool IsInAssaultPhase => currentPhase == TowerDefensePhase.Assault;

    public string CurrentPhaseAsText
    {
        get
        {
            switch(currentPhase)
            {
                case TowerDefensePhase.Build: return "Build Phase";
                case TowerDefensePhase.Assault: return "Assault Phase";
                default: return "error";
            }
        }
    }

    public string EnemiesHeaderTextToDisplay
    {
        get
        {
            switch(currentPhase)
            {
                case TowerDefensePhase.Build: return "Enemies This Round";
                case TowerDefensePhase.Assault: return "Enemies Remaining";
                default: return "error";
            }
        }
    }

    public string NumberOfEnemiesAsText
    {
        get
        {
            switch (currentPhase)
            {
                case TowerDefensePhase.Build: return enemiesThisRound.ToString();
                case TowerDefensePhase.Assault: return EnemiesRemainingThisRound.ToString();
                default: return "error";
            }
        }
    }
    #endregion

    #region Methods
    private void GoToBuildPhase() => currentPhase = TowerDefensePhase.Build;
    private void GoToAssaultPhase() => currentPhase = TowerDefensePhase.Assault;
    private void IncreaseLevel() => currentLevel++;
    private void SetCurrentPhaseText() => currentPhaseText.text = CurrentPhaseAsText;
    private void SetEnemiesHeaderText() => enemiesHeaderText.text = EnemiesHeaderTextToDisplay;
    private void SetEnemiesNumberText() => enemiesCounterText.text = NumberOfEnemiesAsText;
    

    public void StartRound ()
    {
        EnemyManager.Singleton.SetEnemiesRemainingCounter();

        GoToAssaultPhase();

        StartCoroutine(EnemyManager.Singleton.SpawnEnemies());
    }

    #endregion

    public void Start()
    {
        GoToBuildPhase();
    }

    public void Update()
    {
        SetCurrentPhaseText();
        SetEnemiesHeaderText();
        SetEnemiesNumberText();
    }
}