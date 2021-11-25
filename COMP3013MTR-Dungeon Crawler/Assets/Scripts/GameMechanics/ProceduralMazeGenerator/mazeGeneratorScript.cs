using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeGeneratorScript : MonoBehaviour
{
    public MazeScriptableObject mazeToGenerate;
    public colorToObject[] colorToMazeTile;
    public colorToObject[] colorToGameObject;
    public int overallScaleOffset = 1;

    [SerializeField] private int spawnArrayIndex; //For testing purposes to display which spawning positions we are using in the MazeObject

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        spawnArrayIndex = UnityEngine.Random.Range(0, mazeToGenerate.mazeSpawnArray.Length);
=======
>>>>>>> Stashed changes
        GenerateMaze();
    }

    public void GenerateMaze()
    {
        currentMaze = mazesToGenerate[UnityEngine.Random.Range(0, mazesToGenerate.Length)];
        spawnArrayIndex = UnityEngine.Random.Range(0, currentMaze.mazeSpawnArray.Length);
        //To generate tiles in maze
        for(int x = 0; x < mazeToGenerate.mazePixelTexture.width; x++)
        {
            for (int z = 0; z < mazeToGenerate.mazePixelTexture.height; z++)
            {
                GenerateMazeTile(x, z);
            }
        }

        //To generate objects in maze
        for(int x = 0; x < mazeToGenerate.mazeSpawnArray[spawnArrayIndex].width; x++)
        {
            for (int z = 0; z < mazeToGenerate.mazeSpawnArray[spawnArrayIndex].height; z++)
            {
                GenerateGameObject(x, z);
            }
        }
    }

    private void GenerateMazeTile(int x, int z)
    {
        Color pixelColor = mazeToGenerate.mazePixelTexture.GetPixel(x, z); //Get color of pixel within texture

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
        Color pixelColor = mazeToGenerate.mazeSpawnArray[spawnArrayIndex].GetPixel(x, z); //Get color of pixel within texture

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
