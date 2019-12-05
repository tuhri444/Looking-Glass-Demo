using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabs : MonoBehaviour
{
    [SerializeField] public GameObject teleportPrefab;
    [Range(0,15)][SerializeField] public float view;
    [SerializeField] public GameObject PelletPrefab;
    [SerializeField] public List<GameObject> FruitPrefabs;
    [SerializeField] public List<GameObject> PipePrefabs;
}
