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
        if (collision.gameObject.CompareTag("Player")){
            int color = playerPowder.color;
            if(color == 1 && currentColor == 2){
                changeColor(4);
            }
            else if(color == 2 && currentColor == 1){
                changeColor(4);
            }
            else if(color == 1 && currentColor == 3){
                changeColor(6);
            }
            else if(color == 3 && currentColor == 1){
                changeColor(6);
            }
            else if (color == 2 && currentColor == 3){
                changeColor(5);
            }
            else if (color == 3 && currentColor == 2){
                changeColor(5);
            }
            else if (color == 3 && currentColor == 4){
                changeColor(7);
            }
            else if (color == 1 && currentColor == 5){
                changeColor(7);
            }
            else if (color == 2 && currentColor == 6){
                changeColor(7);
            }
            else if ((color == 1 || color == 2) && currentColor == 4){
                changeColor(4);
            }
            else if ((color == 3 || color == 2) && currentColor == 5){
                changeColor(5);
            }
            else if ((color == 1 || color == 3) && currentColor == 6){
                changeColor(6);
            }
            else if (currentColor == 7 && color != 0){
                changeColor(7);
            }
            else
            {
                changeColor(playerPowder.color);
            }
            solChecker.CheckSolution();
        }
    }

    private void changeColor(int color) {
        switch (color) {
            case 0: //white
                thisRenderer.color = new Color(1f, 1f, 1f, 1f);
                this.currentColor = 0;
                break;
            case 1: //yellow
                thisRenderer.color = new Color(0.96f, 0.96f, 0.078f, 1f);
                this.currentColor = 1;
                break;
            case 2: //blue
                thisRenderer.color = new Color(0.1058824f, 0.2526031f, 0.7372549f, 1f);
                this.currentColor = 2;
                break;
            case 3: //red
                thisRenderer.color = new Color(0.8773585f, 0.2110626f, 0.2110626f, 1f);
                this.currentColor = 3;
                break;
            case 4: //green
                thisRenderer.color = new Color(0.086f, 0.79f, 0.199f, 1f);
                this.currentColor = 4;
                break;
            case 5: //purple
                thisRenderer.color = new Color(0.522f, 0.086f, 0.792f, 1f);
                this.currentColor = 5;
                break;
            case 6: //orange
                thisRenderer.color = new Color(0.906f, 0.547f, 0.064f, 1f);
                this.currentColor = 6;
                break;
            case 7: //brown
                thisRenderer.color = new Color(0.462f, 0.279f, 0.033f, 1f);
                this.currentColor = 7;
                break;
        }
    }


}
