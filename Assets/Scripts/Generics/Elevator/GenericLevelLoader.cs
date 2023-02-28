using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericLevelLoader : MonoBehaviour
{
    //public Animator transition;
    //public float transitionTime = 3.0f;
    [SerializeField] GameObject player;
    private PlayerInv playerInv;

    private void Start()
    {
        playerInv = player.GetComponent<PlayerInv>();
    }
    public void LoadNextLevel()
    {
        playerInv.hasKey = false;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(levelIndex);
    }
}

