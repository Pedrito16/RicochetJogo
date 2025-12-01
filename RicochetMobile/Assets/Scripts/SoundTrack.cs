using System.Collections;
using UnityEngine;

public class SoundTrack : MonoBehaviour
{
    [Header("SoundTrack Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] soundtracksPerMap;
    [SerializeField] AudioClip transitionSound;

    [Header("Configuration")]
    [SerializeField] float transitionTime = 2.5f;

    [Header("Readonly")]
    [SerializeField] int currentMapIndex = 0;
    void Start()
    {
        PlaySoundTrack();
        MapsChanger.instance.OnMapSwitch += PlayTransition;
    }
    void Update()
    {
        
    }
    public void PlaySoundTrack()
    {
        currentMapIndex = (currentMapIndex + 1) % soundtracksPerMap.Length;
        if (soundtracksPerMap[currentMapIndex] != null)
        {
            print("Ativei");
            audioSource.clip = soundtracksPerMap[currentMapIndex];

            audioSource.Play();
        }
    }
    public void PlayTransition(CenarioSO cenario)
    {
        audioSource.clip = transitionSound;
        audioSource.Play();
        StartCoroutine(TransitionEnumerator());
    }
    IEnumerator TransitionEnumerator()
    {
        yield return new WaitForSeconds(transitionTime);
        PlaySoundTrack();
    }
}
