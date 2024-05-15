using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStart : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;
    public static bool puzzleActive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleActive && Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }
}
