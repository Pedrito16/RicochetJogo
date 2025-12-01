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
        MapsChanger.instance.OnMapSwitch += PlayTransition;
    }
    void Update()
    {
        
    }
    public void PlaySoundTrack()
    {
        if (soundtracksPerMap[currentMapIndex + 1] != null)
        {
            print("Ativei");
            currentMapIndex = (currentMapIndex + 1) % soundtracksPerMap.Length;
            audioSource.clip = soundtracksPerMap[currentMapIndex];

            audioSource.Play();
            currentMapIndex += 1;
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
