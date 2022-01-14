using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeGeneratorScript : MonoBehaviour
{
    public Vector3 startPos;
    public GameObject player;
    public GameObject shopKeeper;
    public GameObject tileParent;
    public GameObject objParent;
    public MazeScriptableObject[] mazesToGenerate;
    public MazeScriptableObject currentMaze;
    public colorToObject[] colorToMazeTile;
    public colorToObject[] colorToGameObject;
    public int overallScaleOffset = 1;
    public float newMaxHP;

    [SerializeField] private int spawnArrayIndex; //For testing purposes to display which spawning positions we are using in the MazeObject

    // Start is called before the first frame update
    void Start()
    {
        GenerateMaze();
    }

    void Update() 
    {
        tileParent.transform.position = new Vector3(0, 0, 0);
        objParent.transform.position = new Vector3(0, 0, 0);
    }

    public void GenerateMaze()
    {
        currentMaze = mazesToGenerate[UnityEngine.Random.Range(0, mazesToGenerate.Length)];
        spawnArrayIndex = UnityEngine.Random.Range(0, currentMaze.mazeSpawnArray.Length);
        //To generate tiles in maze
        for(int x = 0; x < currentMaze.mazePixelTexture.width; x++)
        {
            for (int z = 0; z < currentMaze.mazePixelTexture.height; z++)
            {
                GenerateMazeTile(x, z);
            }
        }

        //To generate objects in maze
        for(int x = 0; x < currentMaze.mazeSpawnArray[spawnArrayIndex].width; x++)
        {
            for (int z = 0; z < currentMaze.mazeSpawnArray[spawnArrayIndex].height; z++)
            {
                GenerateGameObject(x, z);
            }
        }
    }

    private void GenerateMazeTile(int x, int z)
    {
        Color pixelColor = currentMaze.mazePixelTexture.GetPixel(x, z); //Get color of pixel within texture

        if (pixelColor.a <= 0)
        {
            return; // Skip pixel if it is transparent
        }

        foreach(colorToObject colorMapping in colorToMazeTile)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                colorMapping.Object.transform.localScale = colorMapping.localScale;

                Vector3 pos = new Vector3((overallScaleOffset * (x + colorMapping.offsetX))*6, 
                                            colorMapping.Object.transform.position.y,
                                        (overallScaleOffset * (z + colorMapping.offsetZ))*6);

                Instantiate(colorMapping.Object, pos, Quaternion.identity, tileParent.transform);
            }
        }
    }

    private void GenerateGameObject(int x, int z)
    {
        Color pixelColor = currentMaze.mazeSpawnArray[spawnArrayIndex].GetPixel(x, z); //Get color of pixel within texture

        if (pixelColor.a == 0)
        {
            return; // Skip pixel if it is transparent
        }

        foreach(colorToObject colorMapping in colorToGameObject)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                
                colorMapping.Object.transform.localScale = colorMapping.localScale;

                Vector3 pos = new Vector3((overallScaleOffset * (x + colorMapping.offsetX))*6, 
                                            colorMapping.Object.transform.position.y,
                                        (overallScaleOffset * (z + colorMapping.offsetZ))*6);

                if((colorMapping.Object.name != "Player") && (colorMapping.Object.name != "ShopKeeper"))
                {
                    Instantiate(colorMapping.Object, pos, Quaternion.identity, objParent.transform);
                }

                else if ((colorMapping.Object.name != "Enemy") && (colorMapping.Object.name != "Key") && (colorMapping.Object.name != "mazeEndpoint"))
                {
                    
                    if(colorMapping.Object.name == "Player")
                    {
                        player = colorMapping.Object;
                        startPos = pos;
                    }

                    else if (colorMapping.Object.name == "ShopKeeper")
                    {
                        shopKeeper = colorMapping.Object;
                    }

                    if((player) && (colorMapping.Object.name == "Player"))
                    {
                        player.transform.position = startPos;
                        player.transform.rotation = Quaternion.identity;
                    }

                    else if ((colorMapping.Object.name == "Player") && (player == null))
                    {
                        Instantiate(colorMapping.Object, pos, Quaternion.identity, transform);
                    }

                    if((shopKeeper) && (colorMapping.Object.name == "ShopKeeper"))
                    {
                        shopKeeper.transform.position = startPos;
                        shopKeeper.transform.rotation = Quaternion.identity;
                    }

                    else if ((colorMapping.Object.name == "ShopKeeper") && (shopKeeper == null))
                    {
                        Instantiate(colorMapping.Object, pos, Quaternion.identity, transform);
                    }
                }
            }
        }
    }

    public void ClearMaze()
    {
        foreach(Transform child in tileParent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(Transform child in objParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
