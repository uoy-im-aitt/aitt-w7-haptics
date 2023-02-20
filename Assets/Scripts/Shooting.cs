using UnityEngine;
using System;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public int fireDelay = 1000;
    public int maxAmmo = 10;
    public float explosionForce = 50.0f;
    public string tagFilter = "Target";
    public AudioClip fire;
    public AudioClip noAmmo;

    protected SteamVR_TrackedObject controller;
    private LineRenderer line;
    private DateTime lastFired;
    private AudioSource sound;
    private bool pickedUp;
    private int ammo;

    protected virtual void FireHapticFeedback(bool hasAmmo)
    {
        //
        // YOUR HAPTIC FEEDBACK CODE GOES HERE
        //
    }
    
    void Start ()
    {
        sound = GetComponent<AudioSource>();
        line = GetComponent<LineRenderer>();
        lastFired = DateTime.Now;
        pickedUp = false;
        ammo = maxAmmo;
	}

    public void PickUp()
    {
        controller = GetComponentInParent<SteamVR_TrackedObject>();
        pickedUp = true;
    }

    public void PutDown()
    {
        pickedUp = false;
        line.enabled = false;
    }

    void Update ()
    {
        if(pickedUp)
        {
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject target = hitInfo.collider.gameObject;
                line.SetPosition(0, ray.origin);
                line.SetPosition(1, hitInfo.point);
                line.enabled = true;

                SteamVR_Controller.Device device = SteamVR_Controller.Input((int)controller.index);
                TimeSpan elapsed = DateTime.Now - lastFired;
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && elapsed > TimeSpan.FromMilliseconds(fireDelay))
                {
                    if (ammo > 0)
                    {
                        lastFired = DateTime.Now;
                        sound.PlayOneShot(fire);
                        FireHapticFeedback(true);
                        ammo--;

                        if (target.tag == tagFilter)
                        {
                            Rigidbody rb = target.GetComponent<Rigidbody>();
                            rb.AddExplosionForce(explosionForce, hitInfo.point, 1.0f);
                        }
                    }
                    else
                    {
                        sound.PlayOneShot(noAmmo);
                        FireHapticFeedback(false);
                    }
                }
            }
            else
            {
                line.enabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Ammo")
        {
            ammo = maxAmmo;
        }
    }
}
