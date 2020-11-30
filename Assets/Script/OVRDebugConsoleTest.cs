using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRDebugConsoleTest : MonoBehaviour
{
    OVRDebugConsole console;

    public OVRGrabbable grabbable;

    void Start()
    {
        console = OVRDebugConsole.instance;
    }

    void Update()
    {
        console.AddMessage(grabbable.isGrabbed.ToString(), Color.white);
    }
}
