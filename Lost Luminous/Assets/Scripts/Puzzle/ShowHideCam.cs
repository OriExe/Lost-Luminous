using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideCam : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;

    private void OnEnable()
    {
        puzzle.SetActive(true);
    }
    private void OnDisable()
    {
        puzzle.SetActive(false); 
    }

    private void OnDestroy()
    {
        Destroy(puzzle);
    }
}
