using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dock : MonoBehaviour {

    public float captureTime = 5f;
    [SerializeField] GameObject flag;
    [TextArea]
    [SerializeField] string journalEntry;
    GameObject notebook;
    TextMeshProUGUI textBox;
    float timeLeft;
    bool docked = false;
    bool discovered = false;
    Rigidbody2D balloon;
    [SerializeField] Vector3 flagOffset = new Vector3(0.3f, -1.05f, 0);

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
        GameObject plantedFlag = Instantiate(flag, transform);
        plantedFlag.transform.position = balloon.transform.position + flagOffset;
        textBox.SetText(journalEntry);
        notebook.SetActive(true);
        balloon.gravityScale = 0.1f;
    }
}
