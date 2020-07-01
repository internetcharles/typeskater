using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rail : MonoBehaviour
{
    public GameObject typingManager;
    public Canvas canvas;
    private GameObject character;
    private GameObject typingGame;
    private GameObject railScoreText;
    public GameObject railScoreObj;
    [SerializeField] float timeSpeed = 0.5f;
    public int railScore;
    public RailScore rs;

    void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        rs = railScoreObj.GetComponent<RailScore>();
    }

    public bool touchingRail = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touchingRail = true;
            Time.timeScale = timeSpeed;
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
            StartCoroutine(DisplayScoreAndDestroy());

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

    void Update()
    {
        if (typingGame != null)
        {
            typingGame.transform.position = new Vector3(character.transform.position.x,
                character.transform.position.y + 0.5f, character.transform.position.z);
        }
    }

}
