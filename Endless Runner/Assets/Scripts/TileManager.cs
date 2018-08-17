using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TileManager : MonoBehaviour
{

    #region Public fields

    TileOrigins tileOrigins;
    BoxCollider boxCollider;

    public int numberOfItemsX, numberOfItemsZ;
    public float itemSpacingX, itemSpacingZ;
    public List<GameObject> listOfGameObjects;
    #endregion

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        DefineOrigins();
        CalculateSpacing();

        for (int i = 0; i < numberOfItemsX; i++)
        {
            Debug.DrawRay(tileOrigins.startLeft + Vector3.forward * itemSpacingX * i, Vector2.up, Color.red);
        }

        for (int i = 0; i < numberOfItemsZ; i++)
        {
            Debug.DrawRay(tileOrigins.startLeft + Vector3.right * itemSpacingZ * i, Vector2.up, Color.blue);
        }

        for (int i = 0; i < numberOfItemsX; i++)
        {
            Debug.DrawRay(tileOrigins.midX + Vector3.forward * itemSpacingX * i, Vector2.up, Color.green);
        }

    }

    private void DefineOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        tileOrigins.startLeft = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);
        tileOrigins.startRight = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z);
        tileOrigins.midX = new Vector3(bounds.size.x / bounds.extents.x, bounds.max.y, bounds.min.z);
        tileOrigins.endLeft = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
        tileOrigins.endRight = new Vector3(bounds.max.x, bounds.max.y, bounds.max.z);
    }

    private void CalculateSpacing()
    {
        Bounds bounds = boxCollider.bounds;
        itemSpacingX = bounds.size.z / (numberOfItemsX - 1);
        itemSpacingZ = bounds.size.x / (numberOfItemsZ - 1);
    }

}


public struct TileOrigins
{
    public Vector3 startLeft, startRight;
    public Vector3 midX;
    public Vector3 endLeft, endRight;
}
