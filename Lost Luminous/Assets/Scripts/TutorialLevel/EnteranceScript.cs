using UnityEngine;
using UnityEngine.SceneManagement;

public class EnteranceScript : MonoBehaviour
{
    [SerializeField] private float pickUpRadius;
    [SerializeField] private LayerMask playerMask;
    private bool playerNearItem;
    // Update is called once per frame
    void Update()
    {
        playerNearItem = Physics2D.OverlapCircle(transform.position, pickUpRadius, playerMask);
        if (playerNearItem && pickUpLadder.playerHasLadder)
        {
            //Could add fade effect here
            SceneManager.LoadScene(2); //Load Next level
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);

    }
}
