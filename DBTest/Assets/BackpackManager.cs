using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackpackManager : MonoBehaviour
{
    public bool atrapado;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pony")
        {
            StartCoroutine("CatchPony", other.gameObject);
        }

    }
    IEnumerator CatchPony(GameObject Pony)
    {
        transform.Translate(Vector3.up * 1, Space.World);
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(Pony.gameObject);
        

        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 10);
        yield return new WaitForSeconds(0.4f);
        transform.Rotate(Vector3.left * 10);

        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 10);
        yield return new WaitForSeconds(0.4f);
        transform.Rotate(Vector3.left * 10);

        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 10);
        yield return new WaitForSeconds(0.4f);
        transform.Rotate(Vector3.left * 10);

        atrapado = true;

        if (atrapado)
        {
            SceneManager.LoadScene("QuizVF");
        }

        //return null;
    }
}