using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaixaIdle : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    public static string falaIdle;
    public static bool idleDialogo;

    public static IEnumerator timer;

    [SerializeField]
    private TextMeshProUGUI textoMesh;

    void Start()
    {
        timer = Timer();
    }

    void Update()
    {
        //GetComponent<TextMeshProUGUI>().text = falaIdle;
        textoMesh.text = falaIdle;

        if (!idleDialogo)
        {
            falaIdle = null;
        }
        else
        {
            StartCoroutine(Timer());
        }

        transform.position = alvo.position + new Vector3(0, 2.5f, 0);
     
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        idleDialogo = false;
    }
}