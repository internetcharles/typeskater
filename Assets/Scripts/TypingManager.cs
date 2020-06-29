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
        for (int i = 0; i < 20; i++)
        {
            AddWord();
        }
        display.text = words[0].text;
    }

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord());
        Debug.Log(word.text);

        words.Add(word);
    }


    public void TypeLetter(char letter)
    {
        if (words[0] != null)
        {
            if (words[0].GetNextLetter() == letter)
            {
                words[0].TypeLetter();
                Score.scoreValue += 5;
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
            Score.scoreValue += 50;
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

    public Word(string t)
    {
        text = t;
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

    public bool WordTyped()
    {
        bool wordTyped = (curChar >= text.Length);
        return wordTyped;
    }

}
