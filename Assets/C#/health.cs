using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float _startingHealth;
    public float _currentHealth { get; private set; }

    private void Awake()
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(float _damage) {
        _currentHealth = Mathf.Clamp(_currentHealth - _damage, 0, _startingHealth);

        if (_currentHealth > 0 )
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddHealth(float _value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + _value, 0, _startingHealth);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1.0f);
        }
    }
}
