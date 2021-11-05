using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dica : MonoBehaviour
{
    public float timer;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            check = true;
            timer += Time.deltaTime;
            if (touch.phase == TouchPhase.Stationary && timer >= 2 && check)
            {
                timer = 0;
                check = false;
                Indicacao.indicar = true;
                
            }
        }
        else
        {
            check = false;
            timer = 0;
        }
    }
}
