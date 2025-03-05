using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    [SerializeField] private List<Image> _birdLifeIcons;
    private float _birdAlphaToSet = 0.1f;

    public void DecreaseLife(int life)
    {
        Color birdColor = _birdLifeIcons[life].color;
        birdColor.a = _birdAlphaToSet;
        _birdLifeIcons[life].color = birdColor;
    }
}
