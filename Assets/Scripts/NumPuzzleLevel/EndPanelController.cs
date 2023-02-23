using UnityEngine;

public class EndPanelController : MonoBehaviour
{
    public GameObject endPanel;

    public void OnLeaveButtonClick()
    {
        endPanel.SetActive(false);
    }
}