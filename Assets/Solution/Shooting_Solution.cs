using UnityEngine;
using System;
using System.Collections;
using Valve.VR;
using UnityEngine.UIElements;

public class Shooting_Solution : Shooting
{
    protected override void FireHapticFeedback(bool hasAmmo)
    {
        TaskTwo(hasAmmo);
    }

    void TaskTwo(bool hasAmmo)
    {
        float strength = hasAmmo ? 0.5f : 1.0f;
        float duration = hasAmmo ? 0.1f : 0.05f;

        //SteamVR_Actions.default_Haptic[controller.inputSource].Execute(0, duration, 10, strength);
        SteamVR_Actions.default_Haptic[controller.inputSource].Execute(0, 1.0f, 50, 1.0f);

        Debug.Log("firing haptics");
    }
    
    void TaskOne(bool hasAmmo)
    {
        float duration = hasAmmo ? 1.0f : 0.05f;
        SteamVR_Actions.default_Haptic[controller.inputSource].Execute(0, duration, 10, 1.0f);
    }
}
