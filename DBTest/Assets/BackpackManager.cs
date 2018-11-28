using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BackpackManager : MonoBehaviour
{
    public bool atrapado;
    System.Random rnd = new System.Random();
    int aleatorio;
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
            if (ApplicationModel.primeraMat == 0)
            {
                ApplicationModel.primeraMat++;
            }
            

            aleatorio = rnd.Next(1, 11);
            Debug.Log(aleatorio);
            switch (aleatorio) {
                case 1:
                    SceneManager.LoadScene("QuizRelacional");
                    break;
                case 2:
                    SceneManager.LoadScene("QuizVF");
                    break;
                case 3:
                    SceneManager.LoadScene("QuizMult");
                    break;
                case 4:
                    SceneManager.LoadScene("QuizRelacional");
                    break;
                case 5:
                    SceneManager.LoadScene("QuizVF");
                    break;
                case 6:
                    SceneManager.LoadScene("QuizMult");
                    break;
                case 7:
                    SceneManager.LoadScene("QuizRelacional");
                    break;
                case 8:
                    SceneManager.LoadScene("QuizVF");
                    break;
                case 9:
                    SceneManager.LoadScene("QuizMult");
                    break;
                case 10:
                    SceneManager.LoadScene("QuizVF");
                    break;
            }
            
        }

        //return null;
    }
}