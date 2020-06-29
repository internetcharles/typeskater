using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public GameObject typingManager;
    public Canvas canvas;
    private GameObject character;
    private GameObject typingGame;

    void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    public bool touchingRail = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touchingRail = true;
            Time.timeScale = 0.15f;
            Vector3 typePosition = new Vector3(character.transform.position.x, character.transform.position.y + 0.5f, character.transform.position.z);
            typingGame = Instantiate(typingManager, typePosition, Quaternion.identity, canvas.transform);
            //Instantiate(currentWord, wordPosition, Quaternion.identity, canvas.transform);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touchingRail = false;
            Destroy(typingGame);
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        if (typingGame != null)
        {
            typingGame.transform.position = new Vector3(character.transform.position.x,
                character.transform.position.y + 0.5f, character.transform.position.z);
        }
    }

}
