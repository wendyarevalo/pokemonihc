using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GpsSystem : MonoBehaviour {

    public Transform[] pony;

    Vector2 RInit;
    Vector2 RCurrentPos;
    Vector2 FInit;
    Vector2 FCurrentPosition;
    public Text textMessage;
    public Text textMessage2;
    public Text textPos;

    public float Scale;
    public bool FakingLocation;
    bool isStarted = false;
    

	// Use this for initialization
	void Start () {
        Input.location.Start(0.5f);
        Input.compass.enabled = true;
        FInit = Vector2.zero;

    }
	
	// Update is called once per frame
	void Update () {
  
            StartCoroutine(updatePosition());

        if (!isStarted)
        {
            isStarted = true;
            if (ApplicationModel.primeraMat != 0)
            {
                /*if (ApplicationModel.matActivas >= 3)
                {
                    ApplicationModel.matActivas = 0;
                }
                else
                {*/
                    StartCoroutine(GetMateria(new Vector2(FCurrentPosition.x,FCurrentPosition.y)));
                    /*print(Time.time);
                    yield return new WaitForSeconds(5);
                    print(Time.time);*/
                //}

            }
        }
        

    }

    IEnumerator updatePosition() {
        if (!FakingLocation)
        {
            if (!Input.location.isEnabledByUser)
            {
                //textMessage.text = "Failed because user didn't enable location";
            }
            else
            {
                //textMessage.text = "Success enabled location";
            }

            int maxwait = 20;

            while (Input.location.status == LocationServiceStatus.Initializing && maxwait >= 0)
            {
                yield return new WaitForSeconds(1);
                maxwait--;
            }
            if (maxwait < 1)
            {
                //textMessage.text = "Initialization failed, try again";
                yield return null;
            }
            else
            {
                //textMessage.text = "Initialization Success";
            }
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                //textMessage.text = "Location service status failed";
                yield return null;
            }
            else
            {
                if (RInit == Vector2.zero)
                {
                    RInit = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
                }
                
                SetLocation(Input.location.lastData.latitude, Input.location.lastData.longitude);

            }

            

        }
        else
        {

            RCurrentPos = new Vector2(1.97f + Time.time, 100.1f + Time.time);
            Vector2 delta = new Vector2(RCurrentPos.x - RInit.x, RCurrentPos.y - RInit.y);
            FCurrentPosition = delta * Scale;
            this.transform.position = new Vector3(FCurrentPosition.x, 0, FCurrentPosition.y);

            Debug.Log(RCurrentPos.x + "-" + RCurrentPos.y);
            



        }




    }

    void SetLocation(float latitude, float longitude) {
        Debug.Log(latitude + "-" + longitude);
        if (latitude == 0 && longitude == 0)
        {

        }
        //textMessage.text = "Posición real 1:\n X:" + RCurrentPos.x + ", Y: " + RCurrentPos.y;
        RCurrentPos = new Vector2(latitude, longitude);
        Vector2 delta = new Vector2((RCurrentPos.x - RInit.x)*1000000, (RCurrentPos.y - RInit.y)*1000000);
        //delta = delta * Scale;
        this.transform.position = new Vector3(delta.x, 0, delta.y);
        //textMessage2.text = "Posición modelo:\nX: "+this.transform.position.x + ", Y: " + this.transform.position.y + ", Z: " + this.transform.position.z;
        //textPos.text = "Posición real 2:\n X:" + RCurrentPos.x + ", Y: " + RCurrentPos.y;

    }



    string consultaMateriaURL = "https://ihcmon.000webhostapp.com/consultas.php";

    

    IEnumerator GetMateria(Vector2 pos)
    {
        
        yield return new WaitForSeconds(5f);
        WWWForm form = new WWWForm();
        form.AddField("funcion", "materia_nivel");
        form.AddField("parametros", 1);

        WWW www = new WWW(consultaMateriaURL, form);

        yield return www;

        Debug.Log(www.text);

        Materia materia = new Materia();
        materia = JsonUtility.FromJson<Materia>(www.text);

        Debug.Log(materia.id_materia);

        
        Vector3 newpos = new Vector3(pos.x+100, 114, pos.y+100);
        Instantiate(pony[materia.id_materia - 1], newpos, Quaternion.identity);
        ApplicationModel.matActivas++;
        isStarted = false;

    }


    

}
