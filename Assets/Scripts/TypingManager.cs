using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TypingManager : MonoBehaviour
{

    public List<Word> words;
    Text display;

    // Start is called before the first frame update
    void Start()
    {
        display = gameObject.GetComponent<Text>();
        words.Add(new Word("added"));
        display.text = words[0].text;
    }

    // Update is called once per frame
    void Update()
    {

        string input = Input.inputString;
        if (input.Equals("")) //if we are not typing
            return; // stops this function here

        char c = input[0];
        string typing = "";
        for (int i = 0; i < words.Count; i++)
        {
            Word w = words[i];
            if (w.continueText(c))
            {
                string typed = w.getTyped();
                typing += typed + "\n";
                if (typed.Equals(w.text)) // If what we typed is the word's text
                {
                    // We typed the whole word
                    Debug.Log("TYPED : " + w.text);
                    words.Remove(w);
                    typing = "";
                    break;
                }
            }
        }

        display.text = typing;
    }

    private string GetNewWord()
    {
        return display.text = words[0].text;
    }
}

[System.Serializable]
public class Word
{
    public string text;
    public UnityEvent onTyped;
    private string hasTyped;
    private int curChar = 0;


    public Word(string t)
    {
        text = t;
        hasTyped = "";
        curChar = 0;
    }

    public bool continueText(char c)
    {
        if (c.Equals(text[curChar]))
        {
            curChar++;
            hasTyped = text.Substring(0, curChar);

            if (curChar >= text.Length + 1)
            {
                onTyped.Invoke();
                curChar = 0;
            }
            return true;
        }

        else
        {
            curChar = 0;
            hasTyped = "";
            return false;
        }
    }

    public string getTyped()
    {
        return hasTyped;
    }

}
