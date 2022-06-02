# Playable

## 遇到问题

在编写PlayableQueue 时，使用AnimationClipPlayable的GetDuration方法视图拿到当前动画片段的播放时间，但是拿到是一个表示无穷大的值，根据官方API 返回的是playable的存在时间。比较困惑这个playable的存在时间是什么？

最终是通过 playable.GetAnimationClip().Length 来代表当前动画片段的时间

## 关于动画的学习计划

### 2D

DoTween 插件使用 以及源码

### 3D

Animancer 插件 使用 以及源码研究

Unity 官方动画系统 Animation 与Animator的深度使用

动画插件

Final IK

Dynamic Bone

Magica Cloth

Obi Cloth

VertExmotion





## DoTween 练习

### 单次动画

* 界面的渐隐渐现

*  特效轮流滚动道具界面，最后停留这指定的道具界面上

### 循环动画

* npc按指定的轨迹循环运动，并且随机生成气泡文字

* 