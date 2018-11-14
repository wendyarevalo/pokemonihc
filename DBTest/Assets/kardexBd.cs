using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [Serializable]
    public class KardexBd
    {
        public int id_materia;
        public string clave;


        public KardexBd(int id, string clv)
        {
            id_materia = id;
            clave = clv;
        }
    }

