using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackManager : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pony")
        {
            StartCoroutine("CatchPony", other.gameObject);
        }

    }
    IEnumerator CatchPony(GameObject Pony)
    {
        /*transform.Translate(Vector3.up * 1, Space.World);
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(Pony.gameObject);*/
        return null;
    }
}