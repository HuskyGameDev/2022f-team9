using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControlScript : MonoBehaviour {
    public static MusicControlScript instance; // Creates a static varible for a MusicControlScript instance
    [SerializeField] Slider slider;
    private void Awake() // Runs before void Start()
    {
        DontDestroyOnLoad(this.gameObject); // Don't destroy this gameObject when loading different scenes

        if (instance == null) // If the MusicControlScript instance variable is null
        {
            instance = this; // Set this object as the instance
        }
        else // If there is already a MusicControlScript instance active
        {
            Destroy(gameObject); // Destroy this gameObject
        }
    }

    private void Start() {
        AudioListener.volume = 0.2f;
    }

    public void ChangeVolume() {
        AudioListener.volume = slider.value;
    }
}
