using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLetter : MonoBehaviour
{
    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;
    [SerializeField] private GameObject slot3;
    [SerializeField] private Alphabet alphabet;
    [SerializeField] float delay = .5f;
    [SerializeField] bool wait = false;
    [SerializeField] private GameObject selectionPlane;


    private List<GameObject> letters;
    private VariableManager vm;

    private int index1, index2, index3;
    private int currentSelection = 0;
    private int index;
    float timer = 0;

    

    void Start()
    {
        vm = FindObjectOfType<VariableManager>();
        index = 0;
        timer = 0;
        letters = new List<GameObject>();
        letters.Add(new GameObject());
        letters.Add(new GameObject());
        letters.Add(new GameObject());
        if (letters[0] != null)
            Destroy(letters[index].transform.gameObject);
        letters[0] = Instantiate(alphabet.AlphabetObjects[index1], slot1.transform.position, Quaternion.identity);
        letters[0].transform.rotation = Quaternion.Euler(0, 180, 0);
        if (letters[1] != null)
            Destroy(letters[1].transform.gameObject);
        letters[1] = Instantiate(alphabet.AlphabetObjects[index2], slot2.transform.position, Quaternion.identity);
        letters[1].transform.rotation = Quaternion.Euler(0, 180, 0);
        if (letters[2] != null)
            Destroy(letters[2].transform.gameObject);
        letters[2] = Instantiate(alphabet.AlphabetObjects[index3], slot3.transform.position, Quaternion.identity);
        letters[2].transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void Update()
    {
        if (wait)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal1") < 0 && !wait)
        {
            index--;
            if (index < 0)
            {
                index = 2;
            }
            wait = true;
        }
        if (Input.GetAxis("Horizontal1") > 0 && !wait)
        {
            index++;
            if (index > 2)
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
        

        if (Input.GetAxis("Vertical1") < 0 && !wait)
        {
            if (index == 0)
            {
                index1--;
                if (index1 <= 0)
                {
                    index1 = 25;
                }
            }
            else if (index == 1)
            {
                index2--;
                if (index2 <= 0)
                {
                    index2 = 25;
                }
            }
            else if (index == 2)
            {
                index3--;
                if (index3 <= 0)
                {
                    index3 = 25;
                }
            }
            

            if (index == 0)
            {
                if (letters[index] != null)
                    Destroy(letters[index].transform.gameObject);
                letters[index] = Instantiate(alphabet.AlphabetObjects[index1], slot1.transform.position,
                    Quaternion.identity);
                letters[index].transform.rotation = Quaternion.Euler(0,180,0);
            }
            else if (index == 1)
            {
                if (letters[index] != null)
                    Destroy(letters[index].transform.gameObject);
                letters[index] = Instantiate(alphabet.AlphabetObjects[index2], slot2.transform.position, Quaternion.identity);
                letters[index].transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (index == 2)
            {
                if (letters[index] != null)
                    Destroy(letters[index].transform.gameObject);
                letters[index] = Instantiate(alphabet.AlphabetObjects[index3], slot3.transform.position, Quaternion.identity);
                letters[index].transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            wait = true;
        }
        if (Input.GetAxis("Vertical1") > 0 && !wait)
        {
            if (index == 0)
            {
                index1++;
                if (index1 >= 26)
                {
                    index1 = 0;
                }
            }
            else if (index == 1)
            {

                index2++;
                if (index2 >= 26)
                {
                    index2 = 0;
                }
            }
            else if (index == 2)
            {

                index3++;
                if (index3 >= 26)
                {
                    index3 = 0;
                }
            }

            if (index == 0)
            {
                if (letters[index] != null)
                    Destroy(letters[index].transform.gameObject);
                letters[index] = Instantiate(alphabet.AlphabetObjects[index1], slot1.transform.position,
                    Quaternion.identity);
                letters[index].transform.rotation = Quaternion.Euler(0, 180, 0);

            }
            else if (index == 1)
            {
                if (letters[index] != null)
                    Destroy(letters[index].transform.gameObject);
                letters[index] = Instantiate(alphabet.AlphabetObjects[index2], slot2.transform.position, Quaternion.identity);
                letters[index].transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (index == 2)
            {
                if (letters[index] != null)
                    Destroy(letters[index].transform.gameObject);
                letters[index] = Instantiate(alphabet.AlphabetObjects[index3], slot3.transform.position, Quaternion.identity);
                letters[index].transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            wait = true;
        }

        if (index == 0)
        {
            selectionPlane.transform.position = new Vector3(slot1.transform.position.x, slot1.transform.position.y, slot1.transform.position.z + 0.01f);
        }
        else if (index == 1)
        {
            selectionPlane.transform.position = new Vector3(slot2.transform.position.x, slot2.transform.position.y , slot2.transform.position.z + 0.01f);
        }
        else if (index == 2)
        {
            selectionPlane.transform.position = new Vector3(slot3.transform.position.x, slot3.transform.position.y , slot3.transform.position.z + 0.01f);
        }

        if (Input.GetAxis("A") > 0)
        {
            string namePlayer = alphabet.returnCharacter(index1) + alphabet.returnCharacter(index2) +
                          alphabet.returnCharacter(index3);
            if (PlayerPrefs.GetString("player1Name", "no entry") == "no entry")
            {
                PlayerPrefs.SetInt("player1Score", vm.GetScore());
                PlayerPrefs.SetString("player1Name", namePlayer);
            }
            else
            {
                if (PlayerPrefs.GetInt("player1Score") < vm.GetScore())
                {
                    PlayerPrefs.SetInt("player1Score", vm.GetScore());
                    PlayerPrefs.SetString("player1Name", namePlayer);
                }
                else if (PlayerPrefs.GetInt("player2Score") < vm.GetScore())
                {
                    PlayerPrefs.SetInt("player3Score", PlayerPrefs.GetInt("player2Score"));
                    PlayerPrefs.SetString("player3Name", PlayerPrefs.GetString("player2Score"));
                    PlayerPrefs.SetInt("player4Score", PlayerPrefs.GetInt("player3Score"));
                    PlayerPrefs.SetString("player4Name", PlayerPrefs.GetString("player3Score"));
                    PlayerPrefs.SetInt("player5Score", PlayerPrefs.GetInt("player4Score"));
                    PlayerPrefs.SetString("player5Name", PlayerPrefs.GetString("player4Score"));
                    PlayerPrefs.SetInt("player2Score", vm.GetScore());
                    PlayerPrefs.SetString("player2Name", namePlayer);
                }
                else if(PlayerPrefs.GetInt("player3Score") < vm.GetScore())
                {
                    PlayerPrefs.SetInt("player4Score", PlayerPrefs.GetInt("player3Score"));
                    PlayerPrefs.SetString("player4Name", PlayerPrefs.GetString("player3Score"));
                    PlayerPrefs.SetInt("player5Score", PlayerPrefs.GetInt("player4Score"));
                    PlayerPrefs.SetString("player5Name", PlayerPrefs.GetString("player4Score"));
                    PlayerPrefs.SetInt("player3Score", vm.GetScore());
                    PlayerPrefs.SetString("player3Name", namePlayer);
                }
                else if(PlayerPrefs.GetInt("player4Score") < vm.GetScore())
                {
                    PlayerPrefs.SetInt("player5Score", PlayerPrefs.GetInt("player4Score"));
                    PlayerPrefs.SetString("player5Name", PlayerPrefs.GetString("player4Score"));
                    PlayerPrefs.SetInt("player4Score", vm.GetScore());
                    PlayerPrefs.SetString("player4Name", namePlayer);
                }
                else if(PlayerPrefs.GetInt("player5Score") < vm.GetScore())
                {
                    PlayerPrefs.SetInt("player5Score", vm.GetScore());
                    PlayerPrefs.SetString("player5Name", namePlayer);
                }
            }
            Destroy(vm);
            SceneManager.LoadScene("LeaderboardScene");
        }
    }
}
