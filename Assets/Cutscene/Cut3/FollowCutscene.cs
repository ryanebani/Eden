using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FollowCutscene : MonoBehaviour
{
    public List<GameObject> falas = new List<GameObject>();
    bool first = true;
    bool canClick;
    public int index;
    public UnityEvent OnEnd;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (first) SetFalas();
    }

    void SetFalas()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            falas.Add(gameObject.transform.GetChild(i).gameObject);
        }
        first = false;
    }

    public void StartTexts()
    {
        for (int i = 0; i < falas.Count; i++)
        {
            if (i == 0) falas[i].SetActive(true); canClick = true; 
        }
    }
    public void OnClick()
    {
        if (canClick)
        { 
            if (index < falas.Count)
            {
                falas[index].GetComponent<Animator>().SetTrigger("fala");

                if (index + 1 < falas.Count) falas[index + 1].SetActive(true);                
                index++;
            }
            else
            {
                OnEnd?.Invoke();
            }
        }
    }
}
