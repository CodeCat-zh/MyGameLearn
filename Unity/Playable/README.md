# Playable

## 遇到问题

在编写PlayableQueue 时，使用AnimationClipPlayable的GetDuration方法视图拿到当前动画片段的播放时间，但是拿到是一个表示无穷大的值，根据官方API 返回的是playable的存在时间。比较困惑这个playable的存在时间是什么？

最终是通过 playable.GetAnimationClip().Length 来代表当前动画片段的时间