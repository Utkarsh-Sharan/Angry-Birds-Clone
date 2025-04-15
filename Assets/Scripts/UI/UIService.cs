using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Event;
using Level;

namespace UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private List<Image> _birdLifeIcons;

        [SerializeField] private GameObject _restartScreen;
        [SerializeField] private Image _congratsImage;
        [SerializeField] private Text _loseText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private UIScriptableObject _uIScriptableObject;

        private float _birdAlphaToSet;
        private int _birdLives;

        private void OnEnable()
        {
            _birdAlphaToSet = _uIScriptableObject.BirdAlphaToSet;
            _birdLives = _uIScriptableObject.BirdLives;

            _restartButton.onClick.AddListener(RestartGame);
            EventService.Instance.OnBirdLeftSlingshotEvent.AddListener(DecreaseLife);
        }

        private void DecreaseLife()
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
            EventService.Instance.OnBirdLeftSlingshotEvent.RemoveListener(DecreaseLife);
        }
    }
}