using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
[RequireComponent(typeof(Animator))]
public class UsePlayableQueueSample : MonoBehaviour
{
    public AnimationClip[] clips;
    Animator animator;
    PlayableGraph playableGraph;
    private void Start()
    {
        animator = GetComponent<Animator>();

        playableGraph = PlayableGraph.Create("PlayabeBehaviour");

        AnimationPlayableOutput playableOutput = AnimationPlayableOutput.Create(playableGraph, "PlayableBehaviourOutput", animator);

        var playable = ScriptPlayable<PlayableQueue>.Create(playableGraph, 1);

        PlayableQueue playableQueueBehaviour = playable.GetBehaviour();

        playableQueueBehaviour.Initialize(clips, playable, playableGraph);


        playableOutput.SetSourcePlayable(playable);
    
        playableGraph.Play();
        
    }
    public void OnDestroy()
    {
        playableGraph.Destroy();
    }
}
