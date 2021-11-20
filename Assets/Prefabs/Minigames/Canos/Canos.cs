using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canos : MonoBehaviour
{
    public Cano[] canos;

    public Sprite[] sprites;

    void Update()
    {
        for (int i = 0; i < canos.Length; i++)
        {
            if(canos[i].cima)
            {
                if (i - 4 > -1)
                {
                    if (canos[i - 4].baixo && canos[i - 4].ativo || canos[i - 4].permAtivo)
                    {
                        canos[i].ativo = true;
                    }
                }
            }
            if(canos[i].baixo)
            {
                if (i + 4 < 16)
                {
                    if (canos[i + 4].cima && canos[i + 4].ativo || canos[i + 4].permAtivo)
                    {
                        canos[i].ativo = true;
                    }
                }
            }
            if(canos[i].esq)
            {
                if(i != 0 && i != 4 && i != 8 && i != 12)
                {
                    if (canos[i - 1].dir && canos[i - 1].ativo || canos[i - 1].permAtivo)
                    {
                        canos[i].ativo = true;
                    }
                }
            }
            if (canos[i].dir)
            {
                if (i != 3 && i != 7 && i != 11 && i != 15)
                {
                    if (canos[i + 1].esq && canos[i + 1].ativo || canos[i + 1].permAtivo)
                    {
                        canos[i].ativo = true;
                    }
                }
            }
        }
    }
}
