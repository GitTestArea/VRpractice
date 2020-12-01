using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnStick : MonoBehaviour
{
    public GameObject Stick;
    public GameObject Key;

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("的に当たった!!");
            GameObject.Find("Ball").SetActive(false);
            GameObject.Find("Target").SetActive(false);
            Key.SetActive(true);
            Stick.SetActive(true);
            GameObject.Find("AlarmArea").GetComponent<SphereCollider>().enabled = false;
        }
    }
}
