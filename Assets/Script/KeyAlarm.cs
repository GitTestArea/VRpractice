using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAlarm : MonoBehaviour
{
    public GameObject Alarm;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Character")
        {
            Debug.Log("入った");
            Alarm.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("抜けた");
            Alarm.SetActive(false);
        }
    }
}
