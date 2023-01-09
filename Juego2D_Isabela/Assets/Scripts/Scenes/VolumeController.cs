using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame upda

    public void CambiarVol(float Volumen) 
    {
        audioMixer.SetFloat("Volumen", Volumen);
    }
}
