using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pregunta  {
    public string preguntas="default";
    public string respuesta="default";

    public string Respuesta
    {
        get
        {
            return respuesta;
        }

        set
        {
            respuesta = value;
        }
    }

    public string Preguntas
    {
        get
        {
            return preguntas;
        }

        set
        {
            preguntas = value;
        }
    }
}
