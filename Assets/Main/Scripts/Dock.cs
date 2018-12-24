using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dock : MonoBehaviour {

    public float captureTime = 5f;
    [SerializeField] private GameObject flag;
    [TextArea]
    [SerializeField] string journalEntry;
    GameObject notebook;
    TextMeshProUGUI textBox;
    float timeLeft;
    bool docked = false;
    bool discovered = false;
    Rigidbody2D balloon;

    private void Start()
    {
        notebook = GameObject.Find("Notebook");
        textBox = notebook.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!discovered)
        {
            timeLeft = captureTime;
            docked = true;
            Debug.Log("Enter");
            balloon = collision.gameObject.GetComponent<Rigidbody2D>();
            balloon.gravityScale = 10f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        balloon.gravityScale = 0.1f;
        docked = false;
    }

    private void Update()
    {
        if (docked && !discovered)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Discover();
            }
        }
    }

    private void Discover() {
        discovered = true;
        flag.SetActive(true);
        textBox.SetText(journalEntry);
        notebook.SetActive(true);
        balloon.gravityScale = 0.1f;
    }
}
