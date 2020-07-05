using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickZone : MonoBehaviour
{
    public GameObject typingManager;
    public Canvas canvas;
    private GameObject character;
    private GameObject typingGame;
    public GameObject railScoreObj;
    private GameObject railScoreText;
    public RailScore rs;


    [SerializeField] float timeSpeed = 0.5f;


    void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        rs = railScoreObj.GetComponent<RailScore>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = timeSpeed;
            Vector3 typePosition = new Vector3(character.transform.position.x, character.transform.position.y + 0.5f, character.transform.position.z);
            typingGame = Instantiate(typingManager, typePosition, Quaternion.identity, canvas.transform);
            //Instantiate(currentWord, wordPosition, Quaternion.identity, canvas.transform);
        }

    }

    IEnumerator DisplayScoreAndDestroy()
    {
        Vector3 typePosition = new Vector3(character.transform.position.x, character.transform.position.y + 0.5f, character.transform.position.z);
        railScoreText = Instantiate(railScoreObj, typePosition, Quaternion.identity, canvas.transform);
        yield return new WaitForSeconds(1);
        Destroy(railScoreText);
        RailScore.railScoreValue = 0;
        yield break;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(typingGame);
            Time.timeScale = 1f;

        }

        StartCoroutine(DisplayScoreAndDestroy());
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

