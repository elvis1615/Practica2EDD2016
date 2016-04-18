using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Practica2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestServiceImpl" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestServiceImpl.svc or RestServiceImpl.svc.cs at the Solution Explorer and start debugging.
    public class RestServiceImpl : IRestServiceImpl
    {
        public string JSONData(string id, string a)
        {
            //throw new NotImplementedException();
            return "hola k ase>>" + id +" "+a;
        }

        public void leer(string ruta)
        {
            string line = "";
            string date = "";
            string device = "";
            double dayRank = 0;
            double totalRank = 0;
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(ruta);
            while ((line = file.ReadLine()) != null)
            {
                string[] entradas = line.Split(',');
                date = entradas[0];
                device = entradas[1];
                dayRank = Convert.ToDouble(entradas[2]);
                totalRank = Convert.ToDouble(entradas[3]);
                /*
                aqui se insertan los valores en los arboles
                */

            }

            file.Close();
        }
    }
}
