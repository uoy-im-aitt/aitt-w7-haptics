using UnityEngine;
using System.Collections;
using Valve.VR;

[RequireComponent(typeof(SpringJoint))]
[RequireComponent(typeof(SteamVR_Behaviour_Pose))]
[RequireComponent(typeof(Collider))]
public class ViveSpringGrabber : Grabber
{
    public string grabAction = "GrabPinch";
    private SpringJoint joint;
    
    new void Start ()
    {
        base.Start();
        joint = GetComponent<SpringJoint>();
    }
	
	protected override void Update ()
    {
        if (joint.connectedBody == null && target != null && SteamVR_Input.GetStateDown(grabAction, controller.inputSource))
        {
            joint.connectedBody = target.GetComponent<Rigidbody>();
        }
        else if (joint.connectedBody != null && SteamVR_Input.GetStateUp(grabAction, controller.inputSource))
        {
            joint.connectedBody = null;
        }
    }
}
