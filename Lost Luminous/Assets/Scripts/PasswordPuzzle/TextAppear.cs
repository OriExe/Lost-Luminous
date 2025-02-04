using System.Collections;
using TMPro;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    [SerializeField] private TMP_Text p_Text;
    [Range(1.2f,0f)]
    [SerializeField] private float textSpeed;
    private int visibleCharacters;
    [SerializeField] private TMP_InputField inputField;
    private string input;
    [SerializeField] private string CorrectPassword;
    [SerializeField] private PuzzleStart endPuzzle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showText());
        
    }

    IEnumerator showText()
    {
        while (visibleCharacters <= p_Text.textInfo.characterCount) 
        {
            p_Text.maxVisibleCharacters = ++visibleCharacters;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        inputField.gameObject.SetActive(true);
        inputField.Select();
        
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && inputField.gameObject.activeInHierarchy)
        {
            if (inputField.text.ToLower() == CorrectPassword.ToLower())
            {
                print("You win");
                endPuzzle.endPuzzle();
            }
            else
            {
                print("Wrong password");
                inputField.text = "";
                //Re selects the object 
                inputField.interactable = false;
                inputField.interactable = true;
                inputField.Select();

                
            }

        }
    }
   
}
