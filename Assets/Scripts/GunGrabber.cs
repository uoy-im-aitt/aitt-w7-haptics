using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
[RequireComponent(typeof(Collider))]
public class GunGrabber : Grabber
{
    public Vector3 gunPose;
    public Vector3 gunPosition;

    private GameObject grabbed = null;

    protected new void Start ()
    {
        base.Start();
	}

    protected override void Update ()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);

        if (grabbed == null && target != null && device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            ChangeRendererVisibility(controller, false);

            grabbed = target;
            grabbed.GetComponent<Rigidbody>().isKinematic = true;
            grabbed.transform.parent = transform;
            grabbed.transform.localPosition = gunPosition;
            grabbed.transform.localRotation = Quaternion.Euler(gunPose);
            grabbed.gameObject.GetComponent<Shooting>().PickUp();
            grabbed.GetComponent<Collider>().isTrigger = true;      
        }
        else if(grabbed != null && device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            grabbed.gameObject.GetComponent<Shooting>().PutDown();
            grabbed.transform.parent = null;
            grabbed.GetComponent<Rigidbody>().isKinematic = false;
            grabbed.GetComponent<Collider>().isTrigger = false;
            grabbed = null;

            ChangeRendererVisibility(controller, true);
        }
    }

    private void ChangeRendererVisibility(SteamVR_TrackedObject parent, bool visibility)
    {
        foreach (MeshRenderer child in parent.GetComponentsInChildren<MeshRenderer>())
        {
            child.enabled = visibility;
        }
    }
}
