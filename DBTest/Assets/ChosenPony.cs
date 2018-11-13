using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChosenPony : MonoBehaviour {

    public int idPony;
    // Use this for initialization
    private void OnMouseUp()
    {
        Debug.Log(idPony.ToString());
        Debug.Log(ApplicationModel.ponyId.ToString());

        ApplicationModel.ponyId = this.idPony;
        SceneManager.LoadScene("AtraparPony");
        
    }
}
