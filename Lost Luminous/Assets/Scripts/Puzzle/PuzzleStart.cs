using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStart : MonoBehaviour
{
    private bool playerNear;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float radius;
    [SerializeField] private GameObject puzzle;
    public static bool puzzleActive;
    [SerializeField] private GameObject puzzleDoor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerNear = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if ((playerNear && Input.GetButtonDown("Interact")) && !puzzleActive)
        {
            puzzle.SetActive(true);
            puzzleActive = true;
            Cursor.visible = true;
        }
        //This doesn't work for some reason
        /*
        if (puzzleActive && Input.GetKeyDown(KeyCode.Escape))
        {
            puzzle.SetActive(false);
            puzzleActive = false;
            Cursor.visible = false;
        }
        */


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

    }

    public void endPuzzle()
    {
        puzzleActive = false;
        Cursor.visible = false;
        Destroy(puzzle);
        Destroy(puzzleDoor);
        Destroy(gameObject);
    }
}
