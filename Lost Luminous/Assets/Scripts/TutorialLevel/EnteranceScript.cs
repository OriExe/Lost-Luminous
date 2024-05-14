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
        if (playerNearItem && pickUpLadder.playerHasLadder)
        {
            //Could add fade effect here
            //SceneManager.LoadScene(); //Load Next level
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);

    }
}
