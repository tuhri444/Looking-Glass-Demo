using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    bool active = false;
    public Material selected;
    public Material notSelected;
    ButtonManager bm;
    // Start is called before the first frame update
    void Start()
    {
        bm = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        if (bm.selected == gameObject)
        {
            active = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bm.selected == gameObject)
        {
            active = true;
        } else
        {
            active = false;
        }
        if (active)
        {
            GetComponent<MeshRenderer>().material = selected;
        } else
        {
            GetComponent<MeshRenderer>().material = notSelected;
        }
    }
}
