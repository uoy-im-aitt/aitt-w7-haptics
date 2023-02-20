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

```
float duration = 0.2f;
int frequency = 20;
float strength = 0.75f;

SteamVR_Actions.default_Haptic[controller.inputSource].Execute(0, duration, frequency, strength);
```

a single burst of vibro-tactile feedback that lasts between 0 and 3999 microseconds. To make the controller vibrate from your program, you can use the following code snippet:
