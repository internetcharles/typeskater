using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWord : MonoBehaviour
{

    Text display; 
    TypingManager typingManager;

    // Start is called before the first frame update
    void Start()
    {
        display = gameObject.GetComponent<Text>();
        typingManager = GetComponent<TypingManager>();
        display.text = typingManager.words[0].text;
    }

    // Update is called once per frame
    void Update()
    {
        display.text = typingManager.words[0].text;
    }
}
