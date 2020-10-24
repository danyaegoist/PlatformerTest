using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Slider HealthBar;
    [SerializeField] private float Health;
    [SerializeField] private float MaxHealth = 100;
    [SerializeField] public UnityEvent OnDied;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    private void UpdateHealthBar()
    {
        HealthBar.value = Health / MaxHealth;
    }

    public void ResetHealth()
    {
        Health = MaxHealth;
        UpdateHealthBar();
    }

    public void Hit(float Amount)
    {
        Health -= Amount;
        UpdateHealthBar();

        if (Health <= 0)
            OnDied?.Invoke();
    }
}
