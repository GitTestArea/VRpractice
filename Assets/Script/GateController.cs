using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gate")
        {
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

}
