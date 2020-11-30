using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rote : MonoBehaviour
{
   // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            Debug.Log("Trigger");
            ChangeRotate();
        }
    }
    void ChangeRotate()
    {
        float YAngle = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(0.0f, YAngle + 30.0f, 0.0f);
    }
}
