using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideCam : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;

    private void OnEnable()
    {
        Instantiate(puzzle);
    }
    private void OnDisable()
    {
        Destroy(puzzle);
    }

    private void OnDestroy()
    {

        Destroy(puzzle);
    }
}
