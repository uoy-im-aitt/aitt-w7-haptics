using UnityEngine;
using System.Collections;

public abstract class Grabber : MonoBehaviour
{
    public string tagFilter;

    protected SteamVR_TrackedObject controller;
    protected GameObject target = null;

    protected abstract void Update();

    protected void Start ()
    {
        controller = GetComponent<SteamVR_TrackedObject>();
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
