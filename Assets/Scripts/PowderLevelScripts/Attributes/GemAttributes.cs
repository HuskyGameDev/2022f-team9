using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAttributes : MonoBehaviour {

    [Header("0 = Red, 1 = Green, 2 = Blue")]
    public int color;
    private SpriteRenderer thisRenderer;
    [SerializeField] GameObject torch;
    private TorchAttributes torchAttributes;

    private void Start() {
        color = Random.Range(0, 3);
        thisRenderer = this.GetComponent<SpriteRenderer>();
        torchAttributes = this.torch.GetComponent<TorchAttributes>();
        switch (color) {
            case 0:
                thisRenderer.color = new Color(0.8773585f, 0.2110626f, 0.2110626f, 1f);
                torchAttributes.correctColor = 0;
                break;
            case 1:
                thisRenderer.color = new Color(0.1076006f, 0.735849f, 0.2071944f, 1f);
                torchAttributes.correctColor = 1;
                break;
            case 2:
                thisRenderer.color = new Color(0.1058824f, 0.2526031f, 0.7372549f, 1f);
                torchAttributes.correctColor = 2;
                break;
        }
    }



}
