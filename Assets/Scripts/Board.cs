using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private const int TILE_COUNT_X = 10;
    private const int TILE_COUNT_Y = 10;
    private GameObject[,] tiles;

    private GameObject camera;


    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        GenerateAllTiles(1, TILE_COUNT_X, TILE_COUNT_Y);
    }

    private void GenerateAllTiles(float tileSize, int tileCountX, int tileCountY)
    {
        tiles = new GameObject[tileCountX, tileCountY];


        for (int x = 0; x < tileCountX; x++)
            for (int y = 0; y < tileCountY; y++)
                tiles[x, y] = GenerateSingleTile(tileSize, x, y);



        //camera.transform.position = new Vector3 (1, 1, -10);
    }

    private GameObject GenerateSingleTile(float tileSize, int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tileSize, y * tileSize, 0);
        vertices[1] = new Vector3(x * tileSize, (y+1) * tileSize, 0);
        vertices[2] = new Vector3((x+1) * tileSize, y * tileSize, 0);
        vertices[3] = new Vector3((x+1) * tileSize, (y+1) * tileSize, 0);

        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }
}
