using UnityEngine;
using System.Collections;
using Valve.VR;

public abstract class Grabber : MonoBehaviour
{
    public string tagFilter;

    protected SteamVR_Behaviour_Pose controller;
    protected GameObject target = null;

    protected abstract void Update();

    protected void Start ()
    {
        controller = GetComponent<SteamVR_Behaviour_Pose>();
    }

    protected void OnTriggerEnter(Collider c)
    {
        if (c.tag == tagFilter && target == null)
        {
            target = c.gameObject;
        }
    }

    protected void OnTriggerExit(Collider c)
    {
        if (c.gameObject == target)
        {
            target = null;
        }
    }
}
