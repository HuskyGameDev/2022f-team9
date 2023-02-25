using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionChecker : MonoBehaviour {

    [SerializeField] GameObject key;
    
    [SerializeField] GameObject torch0;
    private TorchAttributes torch0Attributes;
    [SerializeField] GameObject torch1;
    private TorchAttributes torch1Attributes;
    [SerializeField] GameObject torch2;
    private TorchAttributes torch2Attributes;
    [SerializeField] GameObject torch3;
    private TorchAttributes torch3Attributes;
    [SerializeField] GameObject torch4;
    private TorchAttributes torch4Attributes;
    [SerializeField] GameObject torch5;
    private TorchAttributes torch5Attributes;

    public TorchAttributes[] torchAttributes;

    private void Start() {
        torchAttributes = new TorchAttributes[6];

        torch0Attributes = torch0.GetComponent<TorchAttributes>();
        torchAttributes[0] = torch0Attributes;

        torch1Attributes = torch1.GetComponent<TorchAttributes>();
        torchAttributes[1] = torch1Attributes;

        torch2Attributes = torch2.GetComponent<TorchAttributes>();
        torchAttributes[2] = torch2Attributes;

        torch3Attributes = torch3.GetComponent<TorchAttributes>();
        torchAttributes[3] = torch3Attributes;

        torch4Attributes = torch4.GetComponent<TorchAttributes>();
        torchAttributes[4] = torch4Attributes;

        torch5Attributes = torch5.GetComponent<TorchAttributes>();
        torchAttributes[5] = torch5Attributes;
    }

    public void CheckSolution() {
        foreach (TorchAttributes currentAttribute in torchAttributes) {
            if (!(currentAttribute.correctColor == currentAttribute.currentColor)) {
                return;
            }
        }
        Debug.Log("Correct Solution!");
        key.SetActive(true);
    }

}
