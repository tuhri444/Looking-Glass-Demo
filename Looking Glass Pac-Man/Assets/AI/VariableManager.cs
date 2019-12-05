using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariableManager : MonoBehaviour
{
    [HideInInspector]
    public float speed = 10;
    [HideInInspector]
    public bool turning = false;
    [HideInInspector]
    public Quaternion targetRotation;
    [HideInInspector]
    public float turnSpeed = 10;
    [HideInInspector]
    public Vector3 playerPos;
<<<<<<< HEAD
    [HideInInspector]
    public bool startGhost = true;

=======
    [SerializeField] private int Score;
    public int health = 3;

    public bool startGhost;
    private static VariableManager instance;
    public bool gotHit;

    void Awake()
    {
        startGhost = true;
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (health <= 0)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("EndScene");
            health = 3;
        }
    }

    public void AddScore(int scoreToAdd)
    {
        Score += scoreToAdd;
    }
>>>>>>> 95918d362b438326d0c9d702e7d0384254200e1a
}
