using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SentenceManager : MonoBehaviour
{

    public List<Sentence> sentences;
    Text display;

    // Start is called before the first frame update
    void Start()
    {
        display = gameObject.GetComponent<Text>();
        for (int i = 0; i < 20; i++)
        {
            AddSentence();
        }
        display.text = sentences[0].text;
    }

    public void AddSentence()
    {
        Sentence sentence = new Sentence(WordGenerator.GetRandomSentence());
        Debug.Log(sentence.text);

        sentences.Add(sentence);
    }


    public void TypeLetter(char letter)
    {
        if (sentences[0] != null)
        {
            if (sentences[0].GetNextLetter() == letter)
            {
                sentences[0].TypeLetter();
                Score.scoreValue += 5;
                RemoveLetter();
            }
        }
        else
        {
            foreach (Sentence sentence in sentences)
            {
                if (sentence.GetNextLetter() == letter)
                {
                    sentence.TypeLetter();
                    break;
                }
            }
        }

        if (sentences[0] != null && sentences[0].SentenceTyped())
        {
            sentences.Remove(sentences[0]);
            //Score.scoreValue += 50;
            display.text = GetNewSentence();
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

    private string GetNewSentence()
    {
        return display.text = sentences[0].text;
    }

    public void RemoveLetter()
    {
        display.text = display.text.Remove(0, 1);
        display.color = Color.red;
    }

}

[System.Serializable]
public class Sentence
{
    public string text;
    public UnityEvent onTyped;
    private string hasTyped;
    private int curChar = 0;

    public Sentence(string t)
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

    public bool SentenceTyped()
    {
        bool sentenceTyped = (curChar >= text.Length);
        return sentenceTyped;
    }

}

