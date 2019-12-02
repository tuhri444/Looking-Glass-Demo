using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    List<GameObject> buttonList = new List<GameObject>();
    public GameObject firstSelected;
    [HideInInspector] public GameObject selected;
    int pos = 0;
    float delay = 150;
    float timer = 0;
    bool wait = false;
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0;i<transform.childCount;i++)
        {
            buttonList.Add(transform.GetChild(i).gameObject);
        }
        selected = firstSelected;
        //timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                pos++;
                if (pos >= buttonList.Count)
                {
                    pos = 0;
                }
                selected = buttonList[pos];
                wait = true;
                timer = Time.time + delay;
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                pos--;
                if (pos < 0)
                {
                    pos = buttonList.Count - 1;
                }
                selected = buttonList[pos];
                wait = true;
                timer = Time.time + delay;
            }
        } else if(wait)
        {
            if(Time.time < timer)
            {
                wait = false;
            }
        }

    }
}
