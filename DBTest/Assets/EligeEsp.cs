using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EligeEsp : MonoBehaviour {
    

    public Image webIndicador;
    public Image segIndicador;
    public Image softIndicador;
    public TMP_Text exito;
    public Text mensaje;

    private void Start()
    {
        webIndicador.enabled = false;
        segIndicador.enabled = false;
        softIndicador.enabled = false;
        
        StartCoroutine(ConsultaInicial(PlayerPrefs.GetString("no_control")));
    }

    public void clickWeb() {
        StartCoroutine(Seleccion(3));
    }

    public void clickSeg() {
        StartCoroutine(Seleccion(2));
    }

    public void clickSoft() {
        StartCoroutine(Seleccion(1));
    }

    IEnumerator Seleccion(int esp) {
        WWWForm form = new WWWForm();
        form.AddField("funcion", "add_especialidad");
        form.AddField("parametros", "{\"no_control\":" + PlayerPrefs.GetString("no_control") + ",\"especialidad\":" + esp + "}");
        WWW www = new WWW(ApplicationModel.URLConsultas, form);
        yield return www;
        Debug.Log(www.text);
        if (!www.text.Equals("error"))
        {
            segIndicador.enabled = true;
            softIndicador.enabled = true;
            webIndicador.enabled = true;
            exito.text = "¡Exito!";
            mensaje.text = "Felicidades, ya escogiste especialidad. ¡Sigue atrapando ponys!";
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("GameScene");
        }
    }

    IEnumerator ConsultaInicial(string num)
    {
        WWWForm form = new WWWForm();
        form.AddField("funcion", "alumno_materiaInicial");
        form.AddField("parametros", num);
        WWW www = new WWW(ApplicationModel.URLConsultas, form);
        yield return www;

        if (www.text.Equals("3"))
        {
            segIndicador.enabled = true;
        }
        else if (www.text.Equals("2"))
        {
            softIndicador.enabled = true;
        }
        else
        {
            webIndicador.enabled = true;
        }
    }




}
