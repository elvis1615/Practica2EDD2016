using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica2
{
    public class arbolABB
    {
        public NodoArbol raiz;

        public arbolABB() {
            raiz = null;
        }

        public bool vacio() {
            if (raiz == null)
                return true;
            else
                return false;
        }

        public void insertarNodo(NodoArbol nuevo) {
            if (vacio()) {
                raiz = nuevo;
            }
            else {
                raiz.Insertar(nuevo);
            }
        }

        public void PreOrden() {
            Console.Write("\n");
            if (raiz!=null)
            AyudaPreOrden(raiz);
        }

        private void AyudaPreOrden(NodoArbol nodo) {
            if (nodo == null) {
                return;
            }
            Console.Write(nodo.dato+" ");
            AyudaPreOrden(nodo.izquierda);
            AyudaPreOrden(nodo.derecha);
        }

        public void InOrden()
        {
            Console.Write("\n");
            if (raiz != null)
                AyudaInOrden(raiz);
        }

        private void AyudaInOrden(NodoArbol nodo)
        {
            if (nodo == null)
            {
                return;
            }
            
            AyudaPreOrden(nodo.izquierda);
            Console.Write(nodo.dato + " ");
            AyudaPreOrden(nodo.derecha);
        }

        public void PostOrden()
        {
            Console.Write("\n");
            if (raiz != null)
                AyudaPostOrden(raiz);
        }

        private void AyudaPostOrden(NodoArbol nodo)
        {
            if (nodo == null)
            {
                return;
            }

            AyudaPreOrden(nodo.izquierda);            
            AyudaPreOrden(nodo.derecha);
            Console.Write(nodo.dato + " ");
        }

        public NodoArbol Search(int id, NodoArbol r) {
            if (r == null)
            {
                return new NodoArbol(-1);
            }
            else {
                if (id==r.dato) {
                }
                else if (id<r.dato) {
                    return Search(id, r.izquierda);
                }
                else if (id>r.dato) {
                    return Search(id, r.derecha);
                }
            }
            return null;
        }

       
        public void menorValor()
        {
            if (raiz != null)
            {
                NodoArbol reco = raiz;
                while (reco.izquierda != null)
                {
                    reco = reco.izquierda;
                }
                
            }
        }

        public void mayorValor()
        {
            if (raiz != null)
            {
                NodoArbol reco = raiz;
                while (reco.derecha  != null)
                {
                    reco = reco.derecha;
                }
            }
        }

        public bool eliminar(int id) {
            NodoArbol aux=raiz;
            NodoArbol padre = raiz;
            bool hijoIquierdo = true;

            while (aux.dato!=id) {
                if (id < aux.dato)
                {
                    hijoIquierdo = true;
                    aux = aux.izquierda;
                }
                else {
                    hijoIquierdo = false;
                    aux = aux.derecha;
                }
                if (aux == null) {
                    return false;
                }
            } //fin del while
            if (aux.esHoja())
            {
                if (aux == raiz)
                {
                    raiz = null;
                }
                else if (hijoIquierdo)
                {
                    padre.izquierda = null;
                }
                else {
                    padre.derecha = null;
                }
            }
            else if (aux.derecha == null)
            {
                if (aux == raiz)
                {
                    raiz = aux.izquierda;
                }
                else if (hijoIquierdo)
                {
                    padre.izquierda = aux.izquierda;
                }
                else {
                    padre.derecha = aux.izquierda;
                }
            }
            else if (aux.izquierda == null)
            {
                if (aux == raiz)
                {
                    raiz = aux.derecha;
                }
                else if (hijoIquierdo)
                {
                    padre.izquierda = aux.derecha;
                }
                else {
                    padre.derecha = aux.izquierda;
                }
            }
            else {
                NodoArbol reemplazo = obtenerNodoReemplazo(aux);
                if (aux == raiz)
                {
                    raiz = reemplazo;
                }
                else if (hijoIquierdo)
                {
                    padre.izquierda = reemplazo;
                }
                else {
                    padre.derecha = reemplazo;
                }
                reemplazo.izquierda = aux.izquierda;
            }

            return true;
        }

        public NodoArbol obtenerNodoReemplazo(NodoArbol nodoReemp) {
            NodoArbol reemplazarPadre=nodoReemp;
            NodoArbol reemplazo = nodoReemp;
            NodoArbol aux = nodoReemp.derecha;
            while (aux != null) {
                reemplazarPadre = reemplazo;
                reemplazo = aux;
                aux = aux.izquierda;
            }
            if (reemplazo!=nodoReemp.derecha) {
                reemplazarPadre.izquierda = reemplazo.derecha;
                reemplazo.derecha = nodoReemp.derecha;
            }
            Console.WriteLine("se reemplaza nodo "+reemplazo.dato);
            return reemplazo;
        }
    }
}