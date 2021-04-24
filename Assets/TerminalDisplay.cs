using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalDisplay : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    void Awake()
    {
        m_TextComponent = gameObject.GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RevealCharacters(m_TextComponent));
    }

    IEnumerator RevealCharacters(TMP_Text textComponent)
    {
        textComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = textComponent.textInfo;
        Debug.Log("I have " + textInfo.lineCount + " lines");

        int totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
        int visibleCount = 0;

        while (visibleCount < totalVisibleCharacters)
        {
            textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

            visibleCount += 1;
            yield return null;
        }
    }
}
