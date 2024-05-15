using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LinePuzzle
{
    public class EndPoint : MonoBehaviour
    {
        [SerializeField]private EdgeCollider2D Line;
        [SerializeField] private PuzzleStart endPuzzle;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision == Line)
            {
                print("You win");
                endPuzzle.endPuzzle();
            }
        }
    }

}

