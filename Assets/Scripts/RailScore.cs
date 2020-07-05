using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;


public class RailScore : MonoBehaviour
{
    private Text text;
    public static int railScoreValue = 0;
    private GameObject character;
    private string grade;

    void Awake()
    {
        text = GetComponent<Text>();
        character = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (railScoreValue < 50)
        {
            grade = "meh!";
            text.color = Color.red;
        }
        else if (railScoreValue >= 50 && railScoreValue < 100)
        {
            grade = "nice!";
            text.color = Color.blue;
        }
        else if (railScoreValue >= 100)
        {
            grade = "whoa!";
            text.color = Color.green;
        }

        // TODO: reveal rail score update text grab score from typingmanager
        text.text = railScoreValue.ToString() + "\n" + grade;
        Vector2 textPos = new Vector2(character.transform.position.x, character.transform.position.y + 1f);
        transform.position = textPos;
    }

}
