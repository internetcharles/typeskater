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

    public WordGenerator wordSpawner;

    // Start is called before the first frame update
    void Start()
    {
        display = gameObject.GetComponent<Text>();
        AddWord(); AddWord(); AddWord(); AddWord(); AddWord(); AddWord(); AddWord(); AddWord();
        display.text = words[0].text;
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord());
        Debug.Log(word.text);

        words.Add(word);
    }

    // Update is called once per frame
    //void Update()
    //{

    //    string input = Input.inputString;
    //    if (input.Equals("")) //if we are not typing
    //        return; // stops this function here

    //    char c = input[0];
    //    string typing = "";
    //    for (int i = 0; i < words.Count; i++)
    //    {
    //        Word w = words[i];
    //        if (w.continueText(c))
    //        {
    //            string typed = w.getTyped();
    //            typing += typed + "\n";
    //            if (typed.Equals(w.text)) // If what we typed is the word's text
    //            {
    //                // We typed the whole word
    //                Debug.Log("TYPED : " + w.text);
    //                words.Remove(w);
    //                //typing = "";
    //                break;
    //            }
    //        }
    //    }

    //    display.text = typing;
    //}

    public void TypeLetter(char letter)
    {
        if (words[0] != null)
        {
            if (words[0].GetNextLetter() == letter)
            {
                words[0].TypeLetter();
                RemoveLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (words[0] != null && words[0].WordTyped())
        {
            words.Remove(words[0]);
            display.text = GetNewWord();
            display.color = Color.black;
        }
    }

    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            TypeLetter(letter);
        }
    }

    private string GetNewWord()
    {
        return display.text = words[0].text;
    }

    public void RemoveLetter()
    {
        display.text = display.text.Remove(0, 1);
        display.color = Color.red;
    }
}

[System.Serializable]
public class Word
{
    public string text;
    public UnityEvent onTyped;
    private string hasTyped;
    private int curChar = 0;

    public TypingManager typingManager;


    public Word(string t)
    {
        text = t;
        //hasTyped = "";
        curChar = 0;
    }

    public char GetNextLetter()
    {
        return text[curChar];
    }

    public void TypeLetter()
    {
        curChar++;
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

    //public string getTyped()
    //{
    //    return hasTyped;
    //}

    public bool WordTyped()
    {
        bool wordTyped = (curChar >= text.Length);
        return wordTyped;
    }

}
