using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class MixAnimationClip : MonoBehaviour
{

    public Animator animator;
    public float weight1,weight2;
    public AnimationClip clip1, clip2, clip3;
    public PlayableGraph playableGraph;
    public AnimationMixerPlayable mixerPlayable;

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        playableGraph = PlayableGraph.Create("MixAnimation");


        var playableOutput = AnimationPlayableOutput.Create(playableGraph, "MixClipOutput", animator);
        mixerPlayable = AnimationMixerPlayable.Create(playableGraph, 3);

        playableOutput.SetSourcePlayable(mixerPlayable);

        AnimationClipPlayable animationClipPlayable1 = AnimationClipPlayable.Create(playableGraph, clip1);
        AnimationClipPlayable animationClipPlayable2 = AnimationClipPlayable.Create(playableGraph, clip2);
        AnimationClipPlayable animationClipPlayable3 = AnimationClipPlayable.Create(playableGraph, clip3);


        playableGraph.Connect(animationClipPlayable1, 0, mixerPlayable, 0);
        playableGraph.Connect(animationClipPlayable2, 0, mixerPlayable, 1);
        playableGraph.Connect(animationClipPlayable3, 0, mixerPlayable, 2);
      

        playableGraph.Play();
    }

    // Update is called once per frame
    void Update()
    {
        weight1 = Mathf.Clamp(weight1,0,1);
        weight2 = Mathf.Clamp(weight2, 0, 1f - weight1 );
        mixerPlayable.SetInputWeight(0, 1 - weight1 - weight2);
        mixerPlayable.SetInputWeight(1, weight1);
        mixerPlayable.SetInputWeight(2, weight2);

    }

    private void OnDestroy()
    {
        playableGraph.Destroy();
    }
}
