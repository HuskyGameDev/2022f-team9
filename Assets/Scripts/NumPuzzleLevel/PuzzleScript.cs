using UnityEngine;

public class PuzzleScript : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private Transform emptySpace = null;
    private int emptySpaceIndex = 15;
    private Camera _camera;
    [SerializeField] public TileScript[] tiles;
    private bool _isFinished;
    [SerializeField] private GameObject endPanel;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        endPanel.SetActive(false);
        Shuffle();
        ShowBoard(false);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            //when raycast hits object the object is stored in variable hit
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 3.8)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TileScript thisTile = hit.transform.GetComponent<TileScript>();
                    //swap positons of empty space and current hit
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }

        }
        if (!_isFinished)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                    {
                        correctTiles++;
                    }
                }
            }
            if (correctTiles == tiles.Length - 1)
            {
                _isFinished = true;
                Debug.Log(correctTiles);
                endPanel.SetActive(true);
            }
        }

        if (_isFinished)
        {
           ShowBoard(false);
           //playerMovement.runSpeed = 50;
        } 
    }

    public void Shuffle()
    {
        if (emptySpaceIndex != 15)
        {
            var tileOn15LastPos = tiles[15].targetPosition;
            tiles[15].targetPosition = emptySpace.position;
            emptySpace.position = tileOn15LastPos;
            tiles[emptySpaceIndex] = tiles[15];
            tiles[15] = null;
            emptySpaceIndex = 15;
        }
        int inversion;
        do
        {
            for (int i = 0; i <= 14; i++)
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 14);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                //changing index of puzzle tile in array also
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;

            }
            inversion = GetInversions();
            //Debug.Log("Puzzle shuffled");
        } while (inversion % 2 != 0);

    }

    public int findIndex(TileScript ts)
    {
        for(int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if(tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;

    }


    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }

    public void ShowBoard(bool show)
    {
       
        if (show)
        {
            foreach (var tile in tiles)
            {
                if (tile == null)
                {
                    continue;
                }
                var spriteRenderer = tile.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sortingLayerName = "Background3";
                    spriteRenderer.sortingOrder = 1;
                }

                var numObj = tile.transform.Find("Number/Numbers_1");
                if (numObj != null)
                {
                    var numSR = numObj.GetComponent<SpriteRenderer>();
                    if (numSR != null)
                    {
                        numSR.sortingLayerName = "Background2";
                        numSR.sortingOrder = 1;
                    }
                }

                var numObj2 = tile.transform.Find("Number/Numbers_2");
                if (numObj2 != null)
                {
                    var numSR2 = numObj2.GetComponent<SpriteRenderer>();
                    if (numSR2 != null)
                    {
                        numSR2.sortingLayerName = "Background2";
                        numSR2.sortingOrder = 1;
                    }
                }
            }
        }
        else if (show == false)
        {
            foreach (var tile in tiles)
            {
                
                if (tile == null)
                {
                    continue;
                }
                var spriteRenderer = tile.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sortingLayerName = "Background5";
                    spriteRenderer.sortingOrder = -1;
                }

                var numObj = tile.transform.Find("Number/Numbers_1");
                if (numObj != null)
                {
                    var numSR = numObj.GetComponent<SpriteRenderer>();
                    if (numSR != null)
                    {
                        numSR.sortingLayerName = "Background5";
                        numSR.sortingOrder = -1;
                    }
                }

                var numObj2 = tile.transform.Find("Number/Numbers_2");
                if (numObj2 != null)
                {
                    var numSR2 = numObj2.GetComponent<SpriteRenderer>();
                    if (numSR2 != null)
                    {
                        numSR2.sortingLayerName = "Background5";
                        numSR2.sortingOrder = -1;
                    }
                } 
            }
        }
        

    }

   
}
