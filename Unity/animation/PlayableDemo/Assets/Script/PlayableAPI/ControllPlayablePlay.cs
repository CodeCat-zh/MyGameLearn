using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class ControllPlayablePlay : MonoBehaviour
{
    public Animator animator;
    public AnimationClip clip1, clip2;
    public float weight;
    PlayableGraph playableGraph;
    AnimationMixerPlayable animationMixer;
    AnimationClipPlayable animationClip1;
    public bool isPause = false;
    public float playTime = 1.0f;
    public void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        playableGraph = PlayableGraph.Create("MixAnimator");
        AnimationPlayableOutput playableOutput = AnimationPlayableOutput.Create(playableGraph, "MixAnimatorPlayableOutput", animator);
        animationMixer = AnimationMixerPlayable.Create(playableGraph, 2);
        playableOutput.SetSourcePlayable(animationMixer);

        animationClip1 = AnimationClipPlayable.Create(playableGraph, clip1);
        AnimationClipPlayable animationClip2 = AnimationClipPlayable.Create(playableGraph, clip2);
       

        playableGraph.Connect(animationClip1, 0, animationMixer, 0);
        playableGraph.Connect(animationClip2, 0, animationMixer, 1);
        weight = Mathf.Clamp01(weight);
        animationMixer.SetInputWeight(0, 1 - weight);
        animationMixer.SetInputWeight(1, weight);
       
        playableGraph.Play();

        animationClip1.SetDuration(1.0f);

    }
    public void Update()
    {
        if (isPause)
        {
          
            animationClip1.Pause();
        }
        else
        {
           
            animationClip1.Play();
        }
        //animationMixer.SetTime(playTime);//这个方法不起作用
       
    }

    public void OnDestroy()
    {
        playableGraph.Destroy();
    }

}
