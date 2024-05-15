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
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerNear = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if (playerNear && Input.GetButton("Interact"))
        {
            puzzle.SetActive(true);
            puzzleActive = true;
        }
        if (puzzleActive && Input.GetKeyDown(KeyCode.Escape))
        {
            puzzleActive = false;
            puzzle.SetActive(false);
            Cursor.visible = false;
        }


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
