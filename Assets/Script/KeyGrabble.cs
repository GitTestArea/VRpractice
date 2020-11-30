using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGrabble : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Key")
        {
            GameObject.Find("Key").GetComponent<OVRGrabbable>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }

}
