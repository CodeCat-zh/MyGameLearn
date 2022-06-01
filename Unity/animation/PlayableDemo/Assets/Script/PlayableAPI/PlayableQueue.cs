using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class PlayableQueue:PlayableBehaviour
{
    int currentIndex = -1;
    float timeToNextClip = 0f;
    AnimationMixerPlayable mixerPlayable;
    public void Initialize(AnimationClip[] toClip,Playable own,PlayableGraph graph)
    {
        int clipCount = toClip.Length;
        mixerPlayable = AnimationMixerPlayable.Create(graph, clipCount);
        own.SetInputCount(1);
        own.ConnectInput(0, mixerPlayable, 0);

        for(int i  = 0;  i < clipCount; i++)
        {
            var clipPlayable = AnimationClipPlayable.Create(graph, toClip[i]);
            graph.Connect(clipPlayable, 0, mixerPlayable, i);
        }

    }

    public override void PrepareFrame(Playable playable, FrameData info)
    {
        int clipCount = mixerPlayable.GetInputCount();
        if ( clipCount == 0)
        {
            return;
        }
    
        timeToNextClip -= info.deltaTime;
        if (timeToNextClip <= 0 )
        {
            currentIndex++;
            if (currentIndex >= clipCount)
            {
                currentIndex = 0;
            }
            var currentClip =(AnimationClipPlayable) mixerPlayable.GetInput(currentIndex);
            currentClip.SetTime(0);
         
            timeToNextClip = currentClip.GetAnimationClip().length;
        }

        // mixer是通过权重来控制播放
        for( int i = 0; i < clipCount; i++)
        {
            if (i == currentIndex)
            {
                mixerPlayable.SetInputWeight(i, 1);
            }
            else{
                mixerPlayable.SetInputWeight(i, 0);
            }
           
        }
    }
}
