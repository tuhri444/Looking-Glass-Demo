using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabs : MonoBehaviour
{
    [SerializeField] public GameObject PipePrefab;
    [SerializeField] public GameObject teleportPrefab;
    [Range(0,10)][SerializeField] public float view;
    [SerializeField] public GameObject PelletPrefab;
}
