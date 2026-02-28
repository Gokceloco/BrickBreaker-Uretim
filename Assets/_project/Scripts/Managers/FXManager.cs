using UnityEngine;

public class FXManager : MonoBehaviour
{
    public AudioManager audioManager;

    [SerializeField] ParticleSystem impactPS;
    [SerializeField] ParticleSystem brickDestroyedPS;

    public void PlayImpactPS(Vector3 pos, Vector3 normal, Color color)
    {
        var newPS = Instantiate(impactPS);
        newPS.transform.position = pos;
        newPS.transform.LookAt(pos + normal);
        
        var main = newPS.main;
        main.startColor = color;

        newPS.Play();
    }

    public void PlayBrickDestroyedPS(Vector3 pos)
    {
        var newPS = Instantiate(brickDestroyedPS);
        newPS.transform.position = pos;
        newPS.Play();
    }
}
