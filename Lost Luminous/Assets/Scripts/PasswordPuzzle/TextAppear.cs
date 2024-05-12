using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    [SerializeField] private TMP_Text p_Text;
    [Range(0f,1.2f)]
    [SerializeField] private float textSpeed;
    private int visibleCharacters;
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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
