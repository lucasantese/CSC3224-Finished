using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    Text txtLives;
    [SerializeField]
    Text txtScore;
    [SerializeField]
    GameObject gameOverObject;

    [SerializeField]
    Button btnRetry;
    [SerializeField]
    Button btnMenu;

    public void SetResetButtonAction(UnityAction action)
    {
        btnRetry.onClick.AddListener(action);
    }

    public void UpdateScore(int points)
    {
        txtScore.text = $"Score: {points}";
    }

    public void UpdateLives(int lives)
    {
        txtLives.text = $"Lives: {lives}";
    }

    public void ToggleGameOverControls(bool enabled)
    {
        gameOverObject.gameObject.SetActive(enabled);
        btnRetry.gameObject.SetActive(enabled);
        btnMenu.gameObject.SetActive(enabled);
    }
}
