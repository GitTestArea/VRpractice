using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScale : MonoBehaviour
{
    public GameObject Righthand;
    public GameObject Lefthand;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            //Debug.Log("侵入");
            Righthand.SetActive(true);
            Lefthand.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            //Debug.Log("退出");
            Righthand.SetActive(false);
            Lefthand.SetActive(false);
        }
    }
}
