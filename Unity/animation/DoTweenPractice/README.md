# DoTween

## 类介绍

* Tweener : 根据一个值去设置补间动画、

* Sequence : 序列的补间动画

* Nested Tween: 用于连接Sequece的补间动画

## 官方教程翻译

### 配置

DoTween.Init () 和DoTween.SetTweensCapacity()可以改变DoTween的全局配置

```csharp
DoTween.Init(bool recycleAllByDefault = false,bool useSafeMode = true, 
LogBehaviour logBehaviour = LogBehaviour.ErrorsOnly)


DoTween.SetCapacity(int maxTweeners,int maxSequences)
```

`recycleAllByDefault` 如果设置为true就意味着不会销毁Tween而是将其放在一个对象池中，会重用补间对象来避免频繁的GC,但是需要注意补间动画对象的引用，它们执行Kill方法依旧会激活，因为它们可以从对象池重新拿出来使用，导致引用不为空。如果要保证sahn

```csharp
.OnKill(()=> myTweenReference = null)
```

`useSafeMode` : 如果设置为true,tween的执行将会变慢但是更加安全。例如Dotween会发现tween正在运行，并且还没有执行完成，会等它执行完成再将其销毁

注意： 在 iOS 上，safeMode 仅在剥离级别设置为“Strip Assemblies”或脚本调用优化设置为“Slow and Safe”时才有效，而在 Windows 10 WSA 上，如果选择了 Master Configuration 和 .NET，它将不起作用

`LogBehaviour`: errors and warnings everything 三种级别打印输出不同的日志

### 创建Tweener

一共有三种方式，可以创建Tweener：

1. 通用方式
   
   ```csharp
   static DOTween.To(getter,setter,to,float duration)
   /***
   *  getter : 通过委托(delegate)的方式返回一个值给tween,可以写成lambda表达式如下：
   *     ()=> myValue
   *  setter:  通过委托(delegate)的方式去设置一个值，例子如下： x = > myValue = x
   *  to : 结束的值
   *  duration: tween的存在时间
   ***/
   ```

  例子：

```csharp
DOTwwen.To(()=>myVector,x=>myVector = x,new Vector3(3,4,8),1)
```

2. 便捷方式
   
   DoTween对unity一些已知的类型进行扩写，例如： Transform,Rigidbody,Material.你可以直接创建一个对象，然后使用对应的DoTween方法，默认会作用在对象的gameObejct上
   
   例子:
   
   ```csharp
   transform.DOMove(new Vector3(2,3,4),1).From();
   rigidbody.DOMOve(new Vecotr3(2,3,4),1).From();
   material.DoColor(Color.green,1).From()
   ```



#### 所有类型和扩展的方法

##### AudioMixer

DOSetFloat(string floatName,float to,float duration)

##### AudioSource

DOFade(float to,float duration)

DOPitch(float to,float duration)

##### Camera

DOAsepct(float to ,float duration)

DOColor(Color to,float duration)

DOFarClipPlane(float to,float duration)

DOFieldOfView(float to,float duration)

DONearClipPlane(float to,float duration)

DOOrthoSize(float to,float duration)

DOPixelRect(Rect to,float duration)

DORect(Rect to,float duration)

DOShakePositon(float duration, float/Vector3 strength,int vibrato,float randomness ,bool fadeOut)

DOShakeRotation(float duration,float .Vector3 strength,int vibrato,float randomness,bool fadeOut)

##### Light

DOColor(Color to,float duration)

DOIntensity(float to,float duration)

DOShadowStrength(float to,float duration)

DOBlendableColor(Color to,float duration)

##### LigeRenderer

DOColor(Color2 startValue,Color2 endValue,float duration)

##### Material

##### Rigidbody

##### Rigidbody2D

##### SpriteRenderer

##### TrailRenderer

##### Transform



#### Unity UI 4.6

##### CanvasGroup

##### Graphic

##### Iamge

##### LayoutElement

##### Outline

##### RectTransform

##### SrollRect

##### Slider

##### Text

#### Pro 版特供

##### TextMeshPro

##### tk2dBaseSprite

##### tk2dSlicedSprite

##### tk2dTextMesh

### 额外的生成方法