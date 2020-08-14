using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pool", menuName = "Pool")]
public class Pool : ScriptableObject
{
    [SerializeField] private string tag;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int size;

    public string Tag => tag;
    public GameObject Prefab => prefab;
    public int Size => size;
}