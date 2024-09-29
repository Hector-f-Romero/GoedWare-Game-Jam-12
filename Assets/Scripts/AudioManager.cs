using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource; // AudioSource para la música ambiental
    public AudioSource sfxSource;   // AudioSource para efectos de sonido
    public AudioClip[] audioClips;  // Aquí puedes asignar diferentes clips desde el inspector

    // Reproduce el audio que corresponde a un índice en el array de AudioClips (efectos de sonido)
    public void PlaySFX(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            sfxSource.clip = audioClips[index];
            sfxSource.loop = false;
            sfxSource.Play();
        }
        else
        {
            Debug.LogWarning("Índice de audio inválido");
        }
    }

    // Reproduce la música ambiental en loop
    public void PlayMusic(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            musicSource.clip = audioClips[index];
            musicSource.loop = false ;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Índice de música inválido");
        }
    }

    // Detiene la música
    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    // Detiene los efectos de sonido
    public void StopSFX()
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }
    }
}
