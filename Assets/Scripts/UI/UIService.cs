using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private List<Image> _birdLifeIcons;
    [SerializeField] private GameObject _restartScreen;
    [SerializeField] private Button _restartButton;

    private float _birdAlphaToSet = 0.1f;

    private void Awake()
    {
        _restartButton.onClick.AddListener(RestartGame);
    }

    public void DecreaseLife(int life)
    {
        Color birdColor = _birdLifeIcons[life].color;
        birdColor.a = _birdAlphaToSet;
        _birdLifeIcons[life].color = birdColor;
    }

    public void DisplayRestartScreen() => _restartScreen.SetActive(true);

    private void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
