using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class MultiplePlayableOutput : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AnimationClip animationClip;
    public AudioClip audioClip;
    PlayableGraph playableGraph;

    public void Start()
    {
        if (animator == null )
        {
            animator = GetComponent<Animator>();
        }

        if ( audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        playableGraph = PlayableGraph.Create("MultiplePlayableOutput");

        var animationOutput = AnimationPlayableOutput.Create(playableGraph, "AnimationOutput", animator);

        var audioOutput = AudioPlayableOutput.Create(playableGraph, "AudioOutput", audioSource);


        var animationClipPlayable = AnimationClipPlayable.Create(playableGraph, animationClip);

        var audioClipPlayable = AudioClipPlayable.Create(playableGraph, audioClip,true);


        animationOutput.SetSourcePlayable(animationClipPlayable);
        audioOutput.SetSourcePlayable(audioClipPlayable);

        playableGraph.Play();
        
    }

    public void OnDestroy()
    {
        
    }
}
