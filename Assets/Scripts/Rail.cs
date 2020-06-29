using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public GameObject typingManager;
    public GameObject currentWord;
    public Canvas canvas;
    private CharacterMovement characterMovement;
    private GameObject character;

    void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
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
            Vector3 wordPosition = new Vector3(character.transform.position.x, character.transform.position.y + 1f, character.transform.position.z);
            Instantiate(typingManager, typePosition, Quaternion.identity, canvas.transform);
            Instantiate(currentWord, wordPosition, Quaternion.identity, canvas.transform);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touchingRail = false;
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
    }

}
