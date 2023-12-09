using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private health _playerHealth;
    [SerializeField] private Image _totalHelthBar;
    [SerializeField] private Image _currentHelthBar;

    private void Start()
    {

        _totalHelthBar.fillAmount = _playerHealth._currentHealth / 10;

    }

    private void FixedUpdate()
    {
        _currentHelthBar.fillAmount = _playerHealth._currentHealth / 10;
    }
}
