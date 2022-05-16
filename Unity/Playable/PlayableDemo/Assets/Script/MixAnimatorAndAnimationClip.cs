using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class MixAnimatorAndAnimationClip : MonoBehaviour
{
    public Animator animator;
    public AnimationClip clip;
    public RuntimeAnimatorController aimatorController;
    public float weight;
    PlayableGraph playableGraph;
    AnimationMixerPlayable animationMixer;

    public void Start()
    {
        if ( animator == null )
        {
            animator = GetComponent<Animator>();
        }
        playableGraph = PlayableGraph.Create("MixAnimator");
        AnimationPlayableOutput playableOutput = AnimationPlayableOutput.Create(playableGraph, "MixAnimatorPlayableOutput", animator);
        animationMixer = AnimationMixerPlayable.Create(playableGraph, 2);
        playableOutput.SetSourcePlayable(animationMixer);

        AnimationClipPlayable animationClip = AnimationClipPlayable.Create(playableGraph, clip);
        AnimatorControllerPlayable animatorController = AnimatorControllerPlayable.Create(playableGraph, aimatorController);

        playableGraph.Connect(animationClip, 0, animationMixer, 0);
        playableGraph.Connect(animatorController, 0, animationMixer, 1);

        playableGraph.Play();
    }
    public void Update()

    {
        weight = Mathf.Clamp01(weight);
        animationMixer.SetInputWeight(0, 1 - weight);
        animationMixer.SetInputWeight(1, weight);
    }

    public void OnDestroy()
    {
        playableGraph.Destroy();
    }
}
