using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeGeneratorScript : MonoBehaviour
{
    public MazeScriptableObject[] mazesToGenerate;
    public MazeScriptableObject currentMaze;
    public colorToObject[] colorToMazeTile;
    public colorToObject[] colorToGameObject;
    public int overallScaleOffset = 1;

    [SerializeField] private int spawnArrayIndex; //For testing purposes to display which spawning positions we are using in the MazeObject

    // Start is called before the first frame update
    void Start()
    {
        currentMaze = mazesToGenerate[UnityEngine.Random.Range(0, mazesToGenerate.Length)];
        spawnArrayIndex = UnityEngine.Random.Range(0, currentMaze.mazeSpawnArray.Length);
        GenerateMaze();
    }

    public void GenerateMaze()
    {
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

        if (pixelColor.a == 0)
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

                Instantiate(colorMapping.Object, pos, Quaternion.identity, transform);
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

                Instantiate(colorMapping.Object, pos, Quaternion.identity, transform);
            }
        }
    }

    public void ClearMaze()
    {
        foreach (Transform tile in this.transform) {
            GameObject.Destroy(tile.gameObject);
        }
    }
}
