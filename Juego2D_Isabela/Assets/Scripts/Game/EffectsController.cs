using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public AudioSource Fuente1;

    public AudioClip[] Sonidos1;

    public void PonerEfecto(AudioClip clip)
    {
        Fuente1.clip = clip;

        Fuente1.Play();
    }

    public void EfectoSonido()
    {
        int NumeroAleatorio = Random.Range(0, Sonidos1.Length);

        PonerEfecto(Sonidos1[NumeroAleatorio]);
    }
}
