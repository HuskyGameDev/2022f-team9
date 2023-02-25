using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowderController : MonoBehaviour {

    [SerializeField] GameObject player;
    private SpriteRenderer playerRenderer;
    private PlayerPowderController powderController;
    private Color objColor;
    public int color;
    public bool isInRange;

    public KeyCode interactKey;
    public UnityEvent playerInteract;

    private void Start() {
        playerRenderer = player.GetComponent<SpriteRenderer>();
        powderController = player.GetComponent<PlayerPowderController>();
        this.objColor = this.GetComponent<SpriteRenderer>().color;
    }

    private void Update() {
        if (isInRange && Input.GetKeyDown(interactKey)) {
            playerInteract.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            this.isInRange = false;
        }
    }

    public void grabPowder() {
        playerRenderer.color = this.objColor;
        powderController.color = this.color;
    }

}
