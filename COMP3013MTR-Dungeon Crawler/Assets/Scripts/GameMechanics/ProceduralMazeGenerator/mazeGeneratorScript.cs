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
        spawnArrayIndex = UnityEngine.Random.Range(0, mazeToGenerate.mazeSpawnArray.Length);
        GenerateMaze();
    }

    private void GenerateMaze()
    {
        //To generate tiles in maze
        for(int x = 0; x < mazeToGenerate.mazePixelTexture.width; x++)
        {
            for (int z = 0; z < mazeToGenerate.mazePixelTexture.height; z++)
            {
                GenerateMazeTile(x*6, z*6);
            }
        }

        //To generate objects in maze
        for(int x = 0; x < mazeToGenerate.mazeSpawnArray[spawnArrayIndex].width; x++)
        {
            for (int z = 0; z < mazeToGenerate.mazeSpawnArray[spawnArrayIndex].height; z++)
            {
                Debug.Log("Generating tile from Pixel " + x + ", " + z);
                GenerateGameObject(x*6, z*6);
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

                Vector3 pos = new Vector3(overallScaleOffset * (x + colorMapping.offsetX), 
                                            colorMapping.Object.transform.position.y,
                                        overallScaleOffset * (z + colorMapping.offsetZ));

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

        foreach(colorToObject colorMapping in colorToMazeTile)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                colorMapping.Object.transform.localScale = colorMapping.localScale;

                Vector3 pos = new Vector3(overallScaleOffset * (x + colorMapping.offsetX), 
                                            colorMapping.Object.transform.position.y,
                                        overallScaleOffset * (z + colorMapping.offsetZ));

                Instantiate(colorMapping.Object, pos, Quaternion.identity, transform);
            }
        }
    }
}
