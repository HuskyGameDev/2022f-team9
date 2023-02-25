using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAttributes : MonoBehaviour {

    [SerializeField] GameObject player;
    private PlayerPowderController playerPowder;
    [SerializeField] GameObject solCheckerObj;
    private SolutionChecker solChecker;
    private SpriteRenderer thisRenderer;
    public int correctColor;
    public int currentColor;

    private void Start() {
        playerPowder = player.GetComponent<PlayerPowderController>();
        solChecker = solCheckerObj.GetComponent<SolutionChecker>();
        thisRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            changeColor(playerPowder.color);
            solChecker.CheckSolution();
        }
    }

    private void changeColor(int color) {
        switch (color) {
            case 0:
                thisRenderer.color = new Color(0.8773585f, 0.2110626f, 0.2110626f, 1f);
                this.currentColor = 0;
                break;
            case 1:
                thisRenderer.color = new Color(0.1076006f, 0.735849f, 0.2071944f, 1f);
                this.currentColor = 1;
                break;
            case 2:
                thisRenderer.color = new Color(0.1058824f, 0.2526031f, 0.7372549f, 1f);
                this.currentColor = 2;
                break;
        }
    }


}
