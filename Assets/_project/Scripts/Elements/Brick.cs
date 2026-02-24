using DG.Tweening;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int minStartHealth;
    public int maxStartHealth;

    private int _currentHealth;

    [SerializeField] TextMeshPro healthTMP;
    [SerializeField] Transform spriteTransfrom;

    public void StartBrick()
    {
        DecideStartHealth();
        SetHealthTMP(_currentHealth);

        transform.localScale = Vector3.zero;
        transform.DOScale(1, .2f);
    }

    private void DecideStartHealth()
    {
        _currentHealth = Random.Range(minStartHealth, maxStartHealth + 1);
    }

    public void GetHit(int damage)
    {
        _currentHealth -= damage;
        SetHealthTMP(_currentHealth);

        PlayHitFX();

        if (_currentHealth <= 0)
        {
            GetComponentInParent<LevelManager>().BrickDestroyed(this);
            Destroy(gameObject);
        }
    }

    private void PlayHitFX()
    {
        spriteTransfrom.DOKill();
        spriteTransfrom.transform.localScale = Vector3.one * .4f;
        spriteTransfrom.DOScale(.5f, .1f).SetLoops(2, LoopType.Yoyo);

        healthTMP.DOKill();
        healthTMP.color = Color.white;
        healthTMP.DOColor(Color.red, .1f).SetLoops(2, LoopType.Yoyo);
    }

    public void SetHealthTMP(int health)
    {
        healthTMP.text = health.ToString();
    }

    private void OnDestroy()
    {
        spriteTransfrom.DOKill();
        healthTMP.DOKill();
    }
}
