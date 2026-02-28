using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource imapctAS;
    public AudioSource brickDestroyedAS;

    public void PlayImpactAS(float pitch)
    {
        imapctAS.pitch = pitch;
        imapctAS.Play();    
    }

    public void PlayBrickDestroyedAS()
    {
        brickDestroyedAS.Play();
    }

}
