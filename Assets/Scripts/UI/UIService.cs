using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private List<Image> _birdLifeIcons;

    [SerializeField] private GameObject _restartScreen;
    [SerializeField] private Image _congratsImage;
    [SerializeField] private Text _loseText;
    [SerializeField] private Button _restartButton;

    private float _birdAlphaToSet = 0.1f;
    private int _birdLives = 3;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartGame);
    }

    public void DecreaseLife()
    {
        --_birdLives;

        Color birdColor = _birdLifeIcons[_birdLives].color;
        birdColor.a = _birdAlphaToSet;
        _birdLifeIcons[_birdLives].color = birdColor;
    }

    public void DisplayLevelEndScreen(LevelResult levelResult)
    {
        _restartScreen.SetActive(true); 

        if (levelResult == LevelResult.Win)
            _loseText.enabled = false;
        else
            _congratsImage.enabled = false;
    }

    private void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartGame);
    }
}
