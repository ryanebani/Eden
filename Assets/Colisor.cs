using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisor : MonoBehaviour
{
    public ItemOS item;
    public GameObject destruir;
    public Inventario inve;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && item != null && destruir != null)
        {
            Debug.Log("Roi");
            inve.AdicionarItem(item, destruir);
        }

        if (coll.tag == "Player")
        {
            Debug.Log("Salve");
        }
    }
}
