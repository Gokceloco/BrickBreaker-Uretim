using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public TextMeshPro healthTMP;

    public int minStartHealth;
    public int maxStartHealth;

    private int _currentHealth;


    public void StartBrick()
    {
        DecideStartHealth();
        SetHealthTMP(_currentHealth);
    }

    private void DecideStartHealth()
    {
        _currentHealth = Random.Range(minStartHealth, maxStartHealth + 1);
    }

    public void GetHit(int damage)
    {
        _currentHealth -= damage;
        SetHealthTMP(_currentHealth);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetHealthTMP(int health)
    {
        healthTMP.text = health.ToString();
    }
}
