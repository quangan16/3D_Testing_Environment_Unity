using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    
    [field:SerializeField] public int Width { get; set; }

    [field: SerializeField] public int Height { get; set; }

    [SerializeField] private Tile gridPrefab;

    private Camera _cam;

    private static Dictionary<Vector2, Tile> tileDict;
    
    public static Tile selectingTile = null;

    [ColorUsage(true, true)]  public Color oddColor, evenColor;

    public void Awake()
    {
        Setup();
    }

    void Start()
    {
        Init();
    }
    void Update()
    {

    }

    public void Setup()
    {
        _cam = Camera.main;
    }

    public void Init()
    {
       GenerateGrid();
       SetUpCamera();
    }

    public void GenerateGrid()
    {
        tileDict = new Dictionary<Vector2, Tile>();
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                var newTile = Instantiate(gridPrefab, new Vector3(x, y), Quaternion.identity, transform);
                newTile.SetCoordination(x, y);
                bool isOffset = (x % 2 == 0 && y % 2 != 0 || x % 2 != 0 && y % 2 == 0);
                newTile.SetColor(isOffset ? oddColor : evenColor);
                tileDict.TryAdd(new Vector2(x, y), newTile);;
            }

        }
    }

    public void SetUpCamera()
    {
        var camTransform = _cam.transform;
        camTransform.position = new Vector3((float)Width * 0.5f - 0.5f, (float)Height * 0.5f - 0.5f, camTransform.position.z);
        _cam.orthographicSize = (Width>=Height) ? (Width /2) + 1.0f : (Height / 2) + 1.0f;
    }

    public static Tile GetTileSelected(Vector2 input)
    {
        if(tileDict.TryGetValue(input, out Tile tile)) return tile;
        return null;

    }

    

 
}
