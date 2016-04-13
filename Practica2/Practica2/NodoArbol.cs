using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica2
{
    public class NodoArbol
    {
        #region variables   
        public NodoArbol izquierda;
        public int dato;
        public NodoArbol derecha;
        #endregion
        public NodoArbol(int dato) {
            this.dato = dato;
            derecha = izquierda = null;
        }

        public void Insertar(NodoArbol nuevo) {
            if (nuevo.dato<dato) {
                if (izquierda==null) {
                    izquierda = nuevo;
                }
                else {
                    izquierda.Insertar(nuevo);
                }

            } else if (nuevo.dato>dato) {
                if (derecha==null) {
                    derecha = nuevo;
                }
                else {
                    derecha.Insertar(nuevo);
                }
            }
        }

        public bool esHoja() {
            if (izquierda==null && derecha==null) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}