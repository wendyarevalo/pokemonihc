using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnPonys : MonoBehaviour {

    public GameObject[] pony;
    
    string consultaMateriaURL = "https://ihcmon.000webhostapp.com/consultas.php";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        ApplicationModel.pasos++;
        if (ApplicationModel.pasos % 200 == 0)
        {
            
            StartCoroutine(GetMateria(new Vector2(this.transform.position.x, this.transform.position.z)));

            ApplicationModel.pasos = 0;
        }
        
    }

    IEnumerator GetMateria(Vector2 pos)
    {

        yield return new WaitForSeconds(5f);
        WWWForm form = new WWWForm();
        form.AddField("funcion", "materia_nivel");
        form.AddField("parametros", PlayerPrefs.GetString("nivel"));

        WWW www = new WWW(consultaMateriaURL, form);

        yield return www;

        Debug.Log(www.text);

        Materia materia = new Materia();
        materia = JsonUtility.FromJson<Materia>(www.text);

        Debug.Log(materia.id_materia);

        System.Random rnd = new System.Random();
        

        Vector3 newpos = new Vector3(pos.x + rnd.Next(5,10), 3, pos.y + rnd.Next(5, 10));


        if (ApplicationModel.activos.Count > 2)
        {
            Destroy(ApplicationModel.activos[0]);
            Destroy(ApplicationModel.activos[1]);
            Destroy(ApplicationModel.activos[2]);
            ApplicationModel.activos.Clear();
        }
        else {
            ApplicationModel.activos.Add(Instantiate(pony[materia.id_materia - 1], newpos,Quaternion.identity));
            Debug.Log(ApplicationModel.activos[ApplicationModel.activos.Count - 1].transform.position.x + " Mono " + this.transform.position.x);
            Debug.Log(ApplicationModel.activos[ApplicationModel.activos.Count - 1].transform.position.z + " Mono " + this.transform.position.z);

        }
        
            

        
        

    }
}
