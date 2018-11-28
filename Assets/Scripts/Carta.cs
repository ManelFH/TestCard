using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Solo funciones que impliquen al Objeto/Clase Carta**
/// </summary>
public class Carta : MonoBehaviour {
    //public
	public int idCartas=0;
    public Vector3 posicionOriginal;
    public Texture2D texturaReverso;//TODO: C0001
    public float tiempoDelay;//TODO: C0002
    public GameObject crearCartas;//TODO: C0003
    //private
    private Texture2D texturaAnverso;
    private bool Mostrando;
    /// <summary>
    /// Se busca al Parent para encontrar el script CrearCartas.cs
    /// </summary>
    private void Awake()
    {
        crearCartas = GameObject.Find("Scripts");
    }
    void Start()
    {
        EsconderCarta();
    }
    /// <summary>
    /// Cuando se hace click con el mouse, se muestra mensaje del ID de la carta"GameObject"
    /// luego se llama a MostrarCarta()
    /// </summary>
    void OnMouseDown(){
		print (idCartas.ToString());
        MostrarCarta();
	}
	/// <summary>
    /// Asigna a texturaAnverso la textura que se le pasa por parametro _textura
    /// </summary>
    /// <param name="_textura"></param>
	public void AsignarTextura(Texture2D _textura){
        texturaAnverso = _textura;
	}
    /// <summary>
    /// Control de estado de la carta"GameObject", 
    /// si la variable mostrando es false y el atributo .sePuedemostrar = true :
    ///     -Mostrando se cambiara a True
    ///     -Actualizar la textura del Objeto por la texturaAnverso
    ///     -LLama a la funcion HacerClick() pasandole como parámetro el objeto actual
    /// </summary>
    public void MostrarCarta()
    {
        if (!Mostrando && crearCartas.GetComponent<CrearCartas>().sePuedeMostrar)
        {
            Mostrando = true;
            GetComponent<MeshRenderer>().material.mainTexture = texturaAnverso;
            crearCartas.GetComponent<CrearCartas>().HacerClick(this);
        }
    }
    /// <summary>
    /// Invoca la función Eliminar con 2 segundos de delay
    /// </summary>
    public void EliminarCarta()
    {
        Invoke("Eliminar", 1.5F);
    }
    /// <summary>
    /// Destruye el GameObject actual
    /// </summary>
    void Eliminar()
    {
        Destroy(this.gameObject);
    }
    /// <summary>
    /// REF:C0002
    /// Invoca la función Esconder con tiempoDelay como parámetro
    /// Asignar el valor de .sePuedeMostrar como false
    /// </summary>
    public void EsconderCarta()
    {
        Invoke("Esconder", tiempoDelay);
        crearCartas.GetComponent<CrearCartas>().sePuedeMostrar = false;
    }
    /// <summary>
    /// Asignar a la textura del Objeto la texturaReverso
    /// Mostrando se cambiara a false
    /// Asignar el valor de .sePuedeMostrar como true
    /// </summary>
    void Esconder()
    {
        GetComponent<MeshRenderer>().material.mainTexture = texturaReverso;
        Mostrando = false;
        crearCartas.GetComponent<CrearCartas>().sePuedeMostrar = true;
    }
}
