using UnityEngine;
using System.Collections;
using Valve.VR;

[RequireComponent(typeof(HingeJoint))]
public class CreakingLid : MonoBehaviour
{
    public float hapticThreshold;

    private HingeJoint joint;
    private float lastAngle;
    private SteamVR_Behaviour_Pose controller = null;

	void Start ()
    {
        joint = GetComponent<HingeJoint>();
        lastAngle = joint.angle;
	}


    void Update ()
    {
        float current = joint.angle;

        if(controller != null && Mathf.Abs(current - lastAngle) > hapticThreshold)
        {
            //SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);
            //device.TriggerHapticPulse(3999);
            Debug.Log("haptics go brrrrr");

            lastAngle = current;
        }
	}

    void OnTriggerEnter(Collider c)
    {
        SteamVR_Behaviour_Pose target = c.gameObject.GetComponent<SteamVR_Behaviour_Pose>();
        if(target != null)
        {
            controller = target;
        }
    }

    void OnTriggerExit(Collider c)
    {
        print("leave" + c.ToString());

        SteamVR_Behaviour_Pose target = c.gameObject.GetComponent<SteamVR_Behaviour_Pose>();
        if (target != null && target == controller)
        {
            controller = null;
        }
    }
}
