using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLoop : MonoBehaviour {
    public GamePiece[] pieces = new GamePiece[20];
    public BoardPosition[] positions = new BoardPosition[44];

    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;

    private GamePiece selectedPiece = null;

    public Vector3 boardOffset = new Vector3(1.5f, 0.0f, 0.0f);
    public float x_offset = 0.75f;
    public float z_offset = 5.50f;

    private void Start()
    {
        GenerateInitialBoard();
        GenerateBoardPositions();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClickEvent();
        }
    }

    private void HandleMouseClickEvent()
    {
        GamePiece currentPiece = null;
        RaycastHit hit;
        for (int i = 0; i < 20; i++)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("Piece")))
            {
                currentPiece = hit.transform.GetComponent<GamePiece>();
            }
        }

        if (selectedPiece == null && currentPiece != null)
        {
            selectedPiece = currentPiece;
            selectedPiece.SelectPiece();
        }
        else if (selectedPiece == currentPiece)
        {
            selectedPiece.SelectPiece();
            selectedPiece = null;
        }
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
        SetInitialPiecePlacement(p, x);
    }

    private void SetInitialPiecePlacement(GamePiece p, int x)
    {
        float direction = x < 10 ? 1.0f : -1.0f;
        p.transform.position = (Vector3.right * x_offset * ((x % 10) - 9)) + (Vector3.forward * z_offset * direction) + boardOffset;
    }

    private void GenerateBoardPositions()
    {

    }
}
