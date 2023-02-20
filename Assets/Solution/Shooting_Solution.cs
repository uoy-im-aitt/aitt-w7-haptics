using UnityEngine;
using System;
using System.Collections;

public class Shooting_Solution : Shooting
{
    protected override void FireHapticFeedback(bool hasAmmo)
    {
        TaskTwo(hasAmmo);
    }

    IEnumerator LongVibration(float length, ushort strength)
    {
        yield return new WaitForSeconds(0.1f);

        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - start < length)
        {
            //SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);
            //device.TriggerHapticPulse(strength);

            yield return null; // will wait until next frame before continuing
        }
    }

    void TaskTwo(bool hasAmmo)
    {
        int strength = hasAmmo ? 3999 : 1000;
        float length = hasAmmo ? 0.01f : 0.005f;
        StartCoroutine(LongVibration(length, (ushort)strength));    
    }
    
    void TaskOne(bool hasAmmo)
    {
        //SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);

        int duration = hasAmmo ? 3999 : 1000;
        //device.TriggerHapticPulse((ushort)duration);
    }
}
