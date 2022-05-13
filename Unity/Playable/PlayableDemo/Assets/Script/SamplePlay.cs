using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class SamplePlay : MonoBehaviour
{

    public Animator animator;
    public AnimationClip animationClip;
    public PlayableGraph playableGraph;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        AnimationPlayableUtilities.PlayClip(animator, animationClip, out playableGraph);
    }

    private void OnDestroy()
    {
        playableGraph.Destroy();
    }

}
