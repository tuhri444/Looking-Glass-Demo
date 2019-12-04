using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    [SerializeField] private GameObject startItem;

    [SerializeField] GameObject cursor;
    List<GameObject> UIItems = new List<GameObject>();
    [SerializeField] private Vector3 startPosition;
    GameObject selected;
    [SerializeField] private int menuItems;


    float delay = .5f;
    float timer = 0;
    bool wait = false;

    void Start()
    {
        UIItems.Add(transform.GetChild(0).gameObject);
        UIItems.Add(transform.GetChild(1).gameObject);
        UIItems.Add(transform.GetChild(2).gameObject);
        menuItems = 0;
        startPosition = UIItems[menuItems].transform.Find("CursorPos").position;
        selected = UIItems[menuItems];
        timer = Time.time + delay;
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0 && !wait)
        {
            Debug.Log("Selection Change");
            menuItems--;
            if (menuItems < 0)
            {
                menuItems = UIItems.Count-1;
            }
            wait = true;
        }
        if (Input.GetAxis("Vertical") < 0 && !wait)
        {
            Debug.Log("Selection Change");
            menuItems++;
            if (menuItems >= UIItems.Count)
            {
                menuItems = 0;
            }
            wait = true;
        }

        if (Time.time > timer && wait)
        {
            Debug.Log("Change Timer");
            wait = false;
            timer = Time.time + delay;
        }

        selected.GetComponent<MoveSine>().active = false;
        selected = UIItems[menuItems];
        selected.GetComponent<MoveSine>().active = true;
        cursor.transform.position = UIItems[menuItems].transform.Find("CursorPos").position;
    }
}
