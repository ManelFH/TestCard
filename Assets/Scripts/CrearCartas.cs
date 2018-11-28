using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Todas las funciones que impliquen el manejo de los Objetos"cartas"
/// </summary>
public class CrearCartas : MonoBehaviour {
    //public
    public GameObject CartaPrefab;
    public int ancho;//TODO: CC0001
    public int alto;//TODO: CC0002
    public Transform CartasParent;
    public Texture2D[] texturas;//TODO: CC0003
    public Text textoContadorIntentos;
    public bool sePuedeMostrar = true;
    //private
    private List<GameObject> cartas = new List<GameObject>();
    private int contadorClicks = 0;
    private Carta CartaMostrada;

    void Start()
    {
        Crear();
    }
    /// <summary>
    /// REF: CC0001;CC0002
    /// Creación de cartas"GameObject" tomando dos valores linea y columna(ancho x alto)
    /// Añadir las cartas"GameObject" ha una lista
    /// Asignar las cordenadas como posición original
    /// Asignar texturas a las cartas"GameObject"
    /// Barajar posiciones
    /// </summary>
    public void Crear()
    {
        int cont = 0;
        for (int i = 0; i < ancho; i++)
        {
            for (int x = 0; x < alto; x++)
            {
                GameObject cartaTemp = Instantiate(CartaPrefab, new Vector3(x, 0, i), 
                    Quaternion.Euler(new Vector3(0,180,0)));
                cartas.Add(cartaTemp);
                cartaTemp.GetComponent<Carta>().posicionOriginal = new Vector3(x, 0, i);
                cartaTemp.transform.parent = CartasParent;

                cont++;
            }            
        }
        AsignarTexturas();
        Barajar();
    }
    /// <summary>
    /// REF:CC0003
    /// Asignar texturas usando un Array de texturas previamente cargado
    /// Asignar un ID a cada carta
    /// </summary>
    void AsignarTexturas()
    {   
        for(int i = 0; i<cartas.Count; i++)
        {
            cartas[i].GetComponent<Carta>().AsignarTextura(texturas[i/2]);
            cartas[i].GetComponent<Carta>().idCartas = i / 2;
        }
    }
    /// <summary>
    /// Creación de numero aleatorio
    /// Intercambio de posiciones:
    ///     -Cambiar la posición de las cartas"GameObject" seleccionando cartas[i]
    ///      con cartas[aleatorio]
    ///     -Asignar la posición de cartas[aleatorio] con el atributo .posicionOriginal de cartas[i]
    ///     -Asignar el atributo .posicionOriginal de cartas[i] su posición actual
    ///     -Asignar el atributo .posicionOriginal de cartas[aleatorio] su posición actual
    /// </summary>
    void Barajar()
    {
        int aleatorio;
        for(int i=0; i< cartas.Count; i++)
        {
            aleatorio = Random.Range(i, cartas.Count);
            cartas[i].transform.position = cartas[aleatorio].transform.position;
            cartas[aleatorio].transform.position = cartas[i].GetComponent<Carta>().posicionOriginal;
            cartas[i].GetComponent<Carta>().posicionOriginal = cartas[i].transform.position;
            cartas[aleatorio].GetComponent<Carta>().posicionOriginal = cartas[aleatorio].transform.position;
        }
    }
    /// <summary>
    /// Control de estado de la carta"GameObject", se le pasa una (Carta)_carta
    ///     Si CartaMostrada esta vacía, se le asigna _carta
    ///     CartaMostrada tiene valor:
    ///         Se llama a CompararCartas pasandoles _Carta.GameObject y CartaMostrada.GameObject,
    ///         si la función devuelve True, muestra mensaje y elimina esas cartas"GameObject"
    ///         si devuelve False, se llama a EsconderCarta en cada carta"GameObject"
    ///     Aumenta el ContadorClicks
    ///     Se llama a ActualizarUI()
    /// 
    /// </summary>
    /// <param name="_carta"></param>
    public void HacerClick(Carta _carta)
    {
        if(CartaMostrada == null)
        {
            CartaMostrada = _carta;
        } else
        {            
            if(CompararCartas(_carta.gameObject, CartaMostrada.gameObject))
            {
                print("Bienn!");
                _carta.EliminarCarta();
                CartaMostrada.EliminarCarta();
            }
            else
            {
                _carta.EsconderCarta();
                CartaMostrada.EsconderCarta();
            }
            CartaMostrada = null;
        }
        contadorClicks++;
        ActualizarUI();
    }
    /// <summary>
    /// Se le pasa dos cartas"GameObject", si sus ID son iguales devuelve True
    /// en caso contrario devuelve False
    /// </summary>
    /// <param name="carta1"></param>
    /// <param name="carta2"></param>
    /// <returns></returns>
    bool CompararCartas(GameObject carta1, GameObject carta2)
    {
        if (carta1.GetComponent<Carta>().idCartas  ==
            carta2.GetComponent<Carta>().idCartas)
        {
            return true;
        }
        return false;
    }

    public void ActualizarUI()
    {
        textoContadorIntentos.text = "Intentos: " + contadorClicks/2;
    }

}
