using UnityEngine;
using System.Collections;
using Valve.VR;

[RequireComponent(typeof(SteamVR_Behaviour_Pose))]
[RequireComponent(typeof(Collider))]
public class GunGrabber : Grabber
{
    public string pickupGunAction = "GrabGrip";
    public Vector3 gunPose;
    public Vector3 gunPosition;
    public GameObject renderModel;

    private GameObject grabbed = null;

    protected new void Start ()
    {
        base.Start();
	}

    protected override void Update ()
    {
        bool pressDown = SteamVR_Input.GetStateDown(pickupGunAction, controller.inputSource);

        if (grabbed == null && target != null && pressDown)
        {
            ChangeRendererVisibility(false);

            grabbed = target;
            grabbed.GetComponent<Rigidbody>().isKinematic = true;
            grabbed.transform.parent = transform;
            grabbed.transform.localPosition = gunPosition;
            grabbed.transform.localRotation = Quaternion.Euler(gunPose);
            grabbed.gameObject.GetComponent<Shooting>().PickUp();
            grabbed.GetComponent<Collider>().isTrigger = true;      
        }
        else if(grabbed != null && pressDown)
        {
            grabbed.gameObject.GetComponent<Shooting>().PutDown();
            grabbed.transform.parent = null;
            grabbed.GetComponent<Rigidbody>().isKinematic = false;
            grabbed.GetComponent<Collider>().isTrigger = false;
            grabbed = null;

            ChangeRendererVisibility(true);
        }
    }

    private void ChangeRendererVisibility(bool visibility)
    {
        renderModel.SetActive(visibility);
    }
}
