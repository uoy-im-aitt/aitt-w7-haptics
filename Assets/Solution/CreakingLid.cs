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
            SteamVR_Actions.default_Haptic[controller.inputSource].Execute(0, 0.1f, 10, 1.0f);
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
        SteamVR_Behaviour_Pose target = c.gameObject.GetComponent<SteamVR_Behaviour_Pose>();
        if (target != null && target == controller)
        {
            controller = null;
        }
    }
}
