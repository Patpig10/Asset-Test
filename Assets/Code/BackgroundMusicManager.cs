using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one instance of this GameObject exists
        if (FindObjectsOfType<BackgroundMusicManager>().Length > 1)
        {
            Destroy(gameObject); // Destroy duplicates
            return;
        }

        // Keep this GameObject alive between scene changes
        DontDestroyOnLoad(gameObject);

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Play the specified AudioClip on the AudioSource
    public void PlayAudio(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    // Stop the currently playing audio on the AudioSource
    public void StopAudio()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Stop audio playback when scene changes
        StopAudio();
    }
}
