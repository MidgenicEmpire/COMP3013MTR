using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class colorToObject
{
    public Color color; //Object needs to match pixel color in image
    public GameObject Object;
    public Vector3 localScale = new Vector3(1f,1f, 1f);
    public int offsetX;
    public int offsetZ;
    public int scaleOffset;
}
