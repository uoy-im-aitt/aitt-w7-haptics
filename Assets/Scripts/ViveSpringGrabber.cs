using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpringJoint))]
[RequireComponent(typeof(SteamVR_TrackedObject))]
[RequireComponent(typeof(Collider))]
public class ViveSpringGrabber : Grabber
{
    private SpringJoint joint;
    
    new void Start ()
    {
        base.Start();
        joint = GetComponent<SpringJoint>();
    }
	
	protected override void Update ()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);

        if (joint.connectedBody == null && target != null && device.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        {
            joint.connectedBody = target.GetComponent<Rigidbody>();
        }
        else if (joint.connectedBody != null && device.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        {
            joint.connectedBody = null;
        }
    }
}
