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
        float strength = hasAmmo ? 1.0f : 0.5f;
        float duration = hasAmmo ? 0.2f : 0.05f;
        int frequency = hasAmmo ? 10 : 30;

        SteamVR_Actions.default_Haptic[controller.inputSource].Execute(0, duration, frequency, strength);
    }

    void TaskOne(bool hasAmmo)
    {
        float duration = hasAmmo ? 0.1f : 0.05f; ;
        SteamVR_Actions.default_Haptic[controller.inputSource].Execute(0, 0.1f, 10, 1.0f);
    }
}
