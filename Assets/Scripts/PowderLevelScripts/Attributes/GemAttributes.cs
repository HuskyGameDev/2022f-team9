using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAttributes : MonoBehaviour {

    [Header("0 = Red, 1 = Yellow, 2 = Blue")]
    public int color;
    private SpriteRenderer thisRenderer;
    [SerializeField] GameObject torch;
    private TorchAttributes torchAttributes;

    private void Start() {
        color = Random.Range(1, 8);
        thisRenderer = this.GetComponent<SpriteRenderer>();
        torchAttributes = this.torch.GetComponent<TorchAttributes>();
        switch (color) {
            case 1: //yellow
                thisRenderer.color = new Color(0.96f, 0.96f, 0.078f, 1f);
                torchAttributes.correctColor = 1;
                break;
            case 2: //blue
                thisRenderer.color = new Color(0.1058824f, 0.2526031f, 0.7372549f, 1f);
                torchAttributes.correctColor = 2;
                break;
            case 3: //red
                thisRenderer.color = new Color(0.8773585f, 0.2110626f, 0.2110626f, 1f);
                torchAttributes.correctColor = 3;
                break;
            case 4: //green
                thisRenderer.color = new Color(0.086f, 0.79f, 0.199f, 1f);
                torchAttributes.correctColor = 4;
                break;
            case 5: //purple
                thisRenderer.color = new Color(0.522f, 0.086f, 0.792f, 1f);
                torchAttributes.correctColor = 5;
                break;
            case 6: //orange
                thisRenderer.color = new Color(0.906f, 0.547f, 0.064f, 1f);
                torchAttributes.correctColor = 6;
                break;
            case 7: //brown
                thisRenderer.color = new Color(0.462f, 0.279f, 0.033f, 1f);
                torchAttributes.correctColor = 7;
                break;
        }
    }



}
