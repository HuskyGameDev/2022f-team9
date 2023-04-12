
using UnityEngine;

public class TileScript : MonoBehaviour
{
 
    public Vector3 targetPosition;
    private Vector3 correctPosition;
    private SpriteRenderer _sprite;
    public int number;
    public bool inRightPlace;

    public AudioClip correctSound;
    private AudioSource audioSource;
    private bool soundEnabled;
  

    void Awake()
    {
       targetPosition = transform.position;
       correctPosition = transform.position;
        _sprite = GetComponent<SpriteRenderer>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = correctSound;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        if (targetPosition == correctPosition)
        {
            _sprite.color = Color.green;
            if (!inRightPlace && soundEnabled)
            {
                audioSource.Play();
            }
            inRightPlace = true;
        }
        else
        {
            _sprite.color = Color.white;
            inRightPlace = false;
        }
    }

    public void EnableSound(bool enable)
    {
        soundEnabled = enable;
    }
}
