# Practical 6: Prototyping Haptics with the HTC Vive

In the lecture, we learned how haptic interfaces allow a computer to provide us with information via our sense of touch. In this practical, we are going to learn to implement some basic haptic interactions using the HTC Vive. These interactions won’t be as advanced as the examples you saw in the lecture. However, they will show you how using even the most basic vibration feedback can enhance the user experience of a VR game. You should work in groups of 2-3. When deploying your VR experiences, make sure that another team member ‘spots’ the user to make sure they don’t bump or trip into any furniture of fellow students.

To get started, make a copy of this repository (press the ```Use this template``` button) in your GitHub arccount and check it out onto your local machine. Then open up the “HapticsScene”, which contains a simple shooting gallery game. 

Before moving on to the tasks, take turns to try the game out. Think about some different ways that the game could be improved with the addition of haptic feedback while playing. The controls are as follows:

-	Pick up gun: press the grip buttons on the side on the controller while touching the gun
-	Drop gun:  press the grip buttons again
-	Fire: pull the trigger

If you run out of ammunition, you can find some more in the chest to your left. You can open the chest using the “SpringyJoint” interaction technique we learned about last week.

# Task 1: A Simple Gunshot Vibration Pulse

The HTC Vive provides haptic feedback with vibration motors, which are embedded within each of the controllers (one per controller). These vibration motors can provide bursts of vibrotactile feedback, which vary in intensity, frequency and length. The code snippet below shows how to trigger a vibration with the following parameters:

- Length: 0.2 seconds
- Frequency: 20Hz
- Intensity: 75%

```c#
float duration = 0.2f;
int frequency = 20;
float strength = 0.75f;

SteamVR_Actions.default_Haptic[controller.inputSource].Execute(0, duration, frequency, strength);
```

In this first task, you should add some basic haptic feedback to the gun in the scene so that when the gun fires successfully an intense vibration pulse is felt in the controller holding it.

When implementing this behavior, you should write your code within the ‘FireHapticFeedback’ holding method within the ‘Shooting’ script. This method is automatically called by the same when the user fires. 

# Task 2: Manipulating the Vibration Pulse for a Different Effect

In this task, you should extend your implementation so that when the gun is out of ammo and the user tries to fire a different vibration is felt. Consider how you can vary the three parameters to create a sensation that's more like the subtle clicking of a firing pin rather than a gunshot. 

The method has a Boolean parameter ‘hasAmmo’ that you can use to determine whether to provide an intense pulse or a less intense pulse. You can find the Shooting script within the “Scripts” folder in the project.

To complete this task, grab a pair of headphones and see whether your two different haptic effects feel more realistic when paired with sound.

# Task 3: Vibration Patterns for a Creaking Feeling

In this final task you should create a script that provides haptic feedback when the lid of the chest is opened. The feedback should comprise a pattern of pulses that change in frequency depending on the speed at which the user opens and closes the chest. If the chest is opened quickly, then the user should feel a success of pulses in fast succession. If the chest is opened slowly, a series of pulses should be felt in slower succession. This should give a haptic effect that feels a bit like a creaking hinge.

A haptic effect similar to what you are aiming for can be felt in the “Longbow” level of the HTC Vive’s “Lab” demo application, when pulling back the bow string. You can find this application on Steam under “The Lab” (it should already be installed on your PC). 

When completing this task you may find that the “angle” variable of the “HingeJoint” component of the “Top” game object will be of great use:

- https://docs.unity3d.com/ScriptReference/HingeJoint.html

# Optional Extension

If you complete all of the above tasks before the end of the practical, or would like to continue to develop your skills in your free study time, then you should consider experimenting with some of the following tasks:

- Explore how to create a series of vibration pulses that match with the gun fire and reload sound (i.e. a strong pulse, followed by a delay and then two shorter pulses). You will need to explore how to use the use the WaitForSeconds object in a co-routine when completing this task (https://docs.unity3d.com/Manual/Coroutines.html)
- Explore how to create a creaking sound that is played in synchrony with the vibration pulses when opening and closing the chest. The following forum post explains a nice approach to solving this problem: http://answers.unity3d.com/questions/556758/door-opening-sound-according-to-opening-speeddirec.html
