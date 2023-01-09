using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundItem : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource Fuente;
    public AudioClip[] Sonido;

    public void PonerEfecto(AudioClip clip)
    {
        Fuente.clip = clip;
        Fuente.Play();
    }

    public void Itemsound()
    {
        int NumeroAleatorio = Random.Range(0, Sonido.Length);

        PonerEfecto(Sonido[NumeroAleatorio]);
    }
}
