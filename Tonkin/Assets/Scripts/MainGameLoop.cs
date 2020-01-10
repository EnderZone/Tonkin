using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLoop : MonoBehaviour {
    public GamePiece[] pieces = new GamePiece[20];
    public BoardPosition[] positions = new BoardPosition[44];

    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;

    public Vector3 boardOffset = new Vector3(1.5f, 0.0f, 0.0f);
    public float x_offset = 0.75f;
    public float z_offset = 5.50f;

    private void Start()
    {
        GenerateInitialBoard();
    }

    private void Update()
    {

    }

    private void GenerateInitialBoard()
    {
        for (int i = 0; i < 20; i++)
        {
            GeneratePiece(i);
        }
    }

    private void GeneratePiece(int x)
    {
        GameObject go = Instantiate(x < 10 ? playerOnePrefab : playerTwoPrefab) as GameObject;
        go.transform.SetParent(transform);

        GamePiece p = go.GetComponent<GamePiece>();
        pieces[x] = p;
        MovePiece(p, x);
    }

    private void MovePiece(GamePiece p, int x)
    {
        float direction = x < 10 ? 1.0f : -1.0f;
        p.transform.position = (Vector3.right * x_offset * ((x % 10) - 9)) + (Vector3.forward * z_offset * direction) + boardOffset;
    }
}
