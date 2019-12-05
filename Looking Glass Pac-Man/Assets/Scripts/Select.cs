using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    [SerializeField] private GameObject startItem;

    [SerializeField] GameObject cursor;
    [SerializeField] List<GameObject> UIItems;
    [SerializeField] private Vector3 startPosition;
    GameObject selected;
    private int index;

    [SerializeField] float delay = .5f;
    float timer = 0;
    [SerializeField] bool wait = false;

    void Start()
    {
        index = 0;
        startPosition = cursor.transform.position;
        selected = UIItems[0];
        timer = Time.time + delay;
    }

    void Update()
    {
        if (Input.GetAxis("A") > 0)
        {
            switch (index)
            {
                case 0:
                    SceneManager.LoadScene("GameScene");
                    break;
                case 1:
                    SceneManager.LoadScene("LeaderboardScene");
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
        }



        if (wait)
        {
            timer += Time.deltaTime;
        }

        if (Input.GetAxis("Vertical1") < 0 && !wait)
        {
            Debug.Log("test");
            index--;
            if (index < 0)
            {
                index = UIItems.Count-1;
            }
            wait = true;
        }
        if (Input.GetAxis("Vertical1") > 0 && !wait)
        {
            index++;
            if (index >= UIItems.Count)
            {
                index = 0;
            }
            wait = true;
        }

        if (timer > delay)
        {
            wait = false;
            timer = 0;
        }

        selected.GetComponent<MoveSine>().active = false;
        selected = UIItems[index];
        selected.GetComponent<MoveSine>().active = true;
        if (index == 0)
            cursor.transform.position = startPosition;
        else
            cursor.transform.position = new Vector3(cursor.transform.position.x,UIItems[index].GetComponent<MoveSine>().origin.y, cursor.transform.position.z);
    }
}
