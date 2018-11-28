/* TODO
 *REF Carta.cs
 * C0001 = public Texture2D texturaReverso
 *  Se le asigna la textura desde el Unity para mayor comodidad o testeo
 *  Posibilidad de cambiarlo y ponerlo en el código
 * C0002 =  public float tiempoDelay
 *  Se le asigna la un valor desde el Unity para mayor comodidad o testeo
 *  Posibilidad de cambiarlo y ponerlo en el código
 *  Su valor preder. es 1 seg
 * C0003 = public GameObject crearCartas
 *  Necesidad de usar Awake para encontrar el script CrearCartas.cs
 *  
 * REF CrearCartas.cs
 * C0001 = public int ancho
 *  Se le asigna la un valor desde el Unity para mayor comodidad o testeo
 *  Posibilidad de cambiarlo y ponerlo en el código
 *  **1
 * C0002 = public int alto
 *  Se le asigna la un valor desde el Unity para mayor comodidad o testeo
 *  Posibilidad de cambiarlo y ponerlo en el código para poder ponerlo en private
 *  **1
 * C0003 = public Texture2D[] texturas
 *  Se le asignan la texturas desde el Unity para mayor comodidad o testeo
 *  Posibilidad de cambiarlo y ponerlo en el código
 *  
 *  **MI
 *      1.  Posible modificación futura para pedir al usuario que cambie los valores al gusto,
 *          recordando que tiene tiene que ser par el resultado.
 *          O crear multiples resultados con esos dos valores :
 *              -2x2
 *              -2x3
 *              -2x4
 *              -etc
 */