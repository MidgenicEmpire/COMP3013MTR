using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/New Maze", fileName = "new Maze")]
public class MazeScriptableObject : ScriptableObject
{
    public Texture2D mazePixelTexture;
    public Texture2D[] mazeSpawnArray;
}