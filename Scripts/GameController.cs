using UnityEngine;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour
{
    [SerializeField]
    AsteroidFactory asteroidFactory;

    [SerializeField]
    ShipHitController shipHitController;

    [SerializeField]
    GameUI gameUI;

    [Tooltip("If enabled large asteroids will spawn only after all small asteroids have been cleared")]
    [SerializeField]
    bool waveMode;

    [Range(1, 10)]
    [SerializeField]
    int initialAsteroidCount = 1;

    [SerializeField]
    int livesPerGame = 3;

    int AsteroidSpawnIncrementer; //Only for wave mode
    int lives;
    int score = 0;

    void Start()
    {
        if (waveMode)
        {
            asteroidFactory.OnAsteroidReturned += CheckForNewLevel;
        }
        ResetGame();
        gameUI.SetResetButtonAction(ResetGame);
        shipHitController.SetOnHit(DeductLife);
    }

    void ResetGame()
    {
        if (waveMode)
        {
            AsteroidSpawnIncrementer = initialAsteroidCount;
        }
        asteroidFactory.ReturnAllAsteroids();
        score = 0;
        lives = livesPerGame;
        gameUI.UpdateScore(score);
        gameUI.UpdateLives(lives);
        gameUI.ToggleGameOverControls(false);
        asteroidFactory.CreateLargeAsteroid(initialAsteroidCount);
        shipHitController.TogglePlayerObject(true);
    }

    //Only for wave mode, will spawn one more large asteroid than the initialAsteroidCount variable to made the new batch harder
    void CheckForNewLevel()
    {
        if (asteroidFactory.ActiveAsteroidCount == 0)
        {
            AsteroidSpawnIncrementer++;
            asteroidFactory.CreateLargeAsteroid(AsteroidSpawnIncrementer);
        }
    }

    public bool isWaveMode()
    {
        return waveMode;
    }

    public void AddScore(int points)
    {
        score += points;
        gameUI.UpdateScore(score);
    }

    public void DeductLife()
    {
        lives -= 1;
        gameUI.UpdateLives(lives);

        if (lives == 0)
        {
            AudioController.Instance.PlayGameOverSound();
            shipHitController.TogglePlayerObject(false);
            gameUI.ToggleGameOverControls(true);
        }
    }
}
