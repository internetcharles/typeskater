using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    private GameObject character;
    public GameObject SentenceGame;
    public Canvas canvas;

    [SerializeField] private float timeSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = timeSpeed;
                Vector3 typePosition = new Vector3(character.transform.position.x,
                    character.transform.position.y + 0.5f, character.transform.position.z);
                SentenceGame = Instantiate(SentenceGame, typePosition, Quaternion.identity, canvas.transform);
            }
        }

    }
    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Destroy(typingGame);
    //        Time.timeScale = 1f;
    //        StartCoroutine(DisplayScoreAndDestroy());

    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
