using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HingeJoint))]
public class CreakingLid : MonoBehaviour
{
    public float hapticThreshold;

    private HingeJoint joint;
    private float lastAngle;
    private SteamVR_TrackedObject controller = null;

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
            SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);
            device.TriggerHapticPulse(3999);

            lastAngle = current;
        }
	}

    void OnTriggerEnter(Collider c)
    {
        SteamVR_TrackedObject target = c.gameObject.GetComponent<SteamVR_TrackedObject>();
        if(target != null)
        {
            controller = target;
        }
    }

    void OnTriggerExit(Collider c)
    {
        print("leave" + c.ToString());

        SteamVR_TrackedObject target = c.gameObject.GetComponent<SteamVR_TrackedObject>();
        if (target != null && target == controller)
        {
            controller = null;
        }
    }
}
