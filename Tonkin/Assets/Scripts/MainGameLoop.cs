using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLoop : MonoBehaviour {
    public GamePiece[] pieces = new GamePiece[20];
    public BoardPosition[] positions = new BoardPosition[45];
    public ISet<GamePiece> possiblePositions = new HashSet<GamePiece>();
    public ISet<GameSet> winning_sets = new HashSet<GameSet>();

    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    public GameObject openSpotPrefab;

    private GamePiece selectedPiece = null;

    public Vector3 boardOffset = new Vector3(1.5f, 0.0f, 0.0f);
    public float x_offset = 0.75f;
    public float z_offset = 5.50f;

    private void Start()
    {
        GenerateInitialBoard();
        GenerateBoardPositions();
        GenerateWinningSets();
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
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = new BoardPosition(i);
        }
    }

    private void GenerateWinningSets()
    {
        // 5 -- top row
        GameSet gs = new GameSet();
        gs.addToSet(positions[0]);
        gs.addToSet(positions[1]);
        gs.addToSet(positions[2]);
        gs.addToSet(positions[3]);
        gs.addToSet(positions[4]);
        winning_sets.Add(gs);

        // 5 - left coloumn
        gs = new GameSet();
        gs.addToSet(positions[0]);
        gs.addToSet(positions[9]);
        gs.addToSet(positions[20]);
        gs.addToSet(positions[29]);
        gs.addToSet(positions[40]);
        winning_sets.Add(gs);

        // 7 - top left to bottom right diagonal
        gs = new GameSet();
        gs.addToSet(positions[0]);
        gs.addToSet(positions[5]);
        gs.addToSet(positions[10]);
        gs.addToSet(positions[22]);
        gs.addToSet(positions[34]);
        gs.addToSet(positions[39]);
        gs.addToSet(positions[44]);
        winning_sets.Add(gs);

        // 3 - top left short diagonal
        gs = new GameSet();
        gs.addToSet(positions[1]);
        gs.addToSet(positions[5]);
        gs.addToSet(positions[12]);
        winning_sets.Add(gs);

        // 7 - top left to bottom right short diagonal
        gs = new GameSet();
        gs.addToSet(positions[0]);
        gs.addToSet(positions[7]);
        gs.addToSet(positions[11]);
        gs.addToSet(positions[22]);
        gs.addToSet(positions[33]);
        gs.addToSet(positions[37]);
        gs.addToSet(positions[43]);
        winning_sets.Add(gs);

        // 5 top middle to left middle diagonal
        gs = new GameSet();
        gs.addToSet(positions[2]);
        gs.addToSet(positions[7]);
        gs.addToSet(positions[10]);
        gs.addToSet(positions[16]);
        gs.addToSet(positions[20]);
        winning_sets.Add(gs);

        // 5 - top middle to right middle diagonal
        gs = new GameSet();
        gs.addToSet(positions[2]);
        gs.addToSet(positions[8]);
        gs.addToSet(positions[14]);
        gs.addToSet(positions[17]);
        gs.addToSet(positions[24]);
        winning_sets.Add(gs);

        // 5 - top middle column
        gs = new GameSet();
        gs.addToSet(positions[2]);
        gs.addToSet(positions[12]);
        gs.addToSet(positions[22]);
        gs.addToSet(positions[32]);
        gs.addToSet(positions[42]);
        winning_sets.Add(gs);

        // 3 - top right short diagonal
        gs = new GameSet();
        gs.addToSet(positions[3]);
        gs.addToSet(positions[6]);
        gs.addToSet(positions[15]);
        winning_sets.Add(gs);

        // 7 - top right to bottom left short diagonal
        gs = new GameSet();
        gs.addToSet(positions[3]);
        gs.addToSet(positions[8]);
        gs.addToSet(positions[13]);
        gs.addToSet(positions[22]);
        gs.addToSet(positions[31]);
        gs.addToSet(positions[36]);
        gs.addToSet(positions[41]);
        winning_sets.Add(gs);

        // 7 - top right to bottom left short diagonal
        gs = new GameSet();
        gs.addToSet(positions[4]);
        gs.addToSet(positions[6]);
        gs.addToSet(positions[14]);
        gs.addToSet(positions[22]);
        gs.addToSet(positions[30]);
        gs.addToSet(positions[38]);
        gs.addToSet(positions[40]);
        winning_sets.Add(gs);

        // 5 - top right column
        gs = new GameSet();
        gs.addToSet(positions[4]);
        gs.addToSet(positions[15]);
        gs.addToSet(positions[24]);
        gs.addToSet(positions[35]);
        gs.addToSet(positions[44]);
        winning_sets.Add(gs);

        // 7 - left up to right down diagonal
        gs = new GameSet();
        gs.addToSet(positions[9]);
        gs.addToSet(positions[16]);
        gs.addToSet(positions[18]);
        gs.addToSet(positions[22]);
        gs.addToSet(positions[26]);
        gs.addToSet(positions[28]);
        gs.addToSet(positions[35]);
        winning_sets.Add(gs);

        // 7 - right up to left down diagonal
        gs = new GameSet();
        gs.addToSet(positions[15]);
        gs.addToSet(positions[17]);
        gs.addToSet(positions[19]);
        gs.addToSet(positions[22]);
        gs.addToSet(positions[25]);
        gs.addToSet(positions[27]);
        gs.addToSet(positions[29]);
        winning_sets.Add(gs);

        // 5 - middle row
        gs = new GameSet();
        gs.addToSet(positions[20]);
        gs.addToSet(positions[21]);
        gs.addToSet(positions[22]);
        gs.addToSet(positions[23]);
        gs.addToSet(positions[24]);
        winning_sets.Add(gs);

        // 5 - middle left to bottom middle
        gs = new GameSet();
        gs.addToSet(positions[20]);
        gs.addToSet(positions[27]);
        gs.addToSet(positions[30]);
        gs.addToSet(positions[36]);
        gs.addToSet(positions[42]);
        winning_sets.Add(gs);

        // 5 - middle right to bottom middle
        gs = new GameSet();
        gs.addToSet(positions[24]);
        gs.addToSet(positions[28]);
        gs.addToSet(positions[34]);
        gs.addToSet(positions[37]);
        gs.addToSet(positions[42]);
        winning_sets.Add(gs);

        // 3 - bottom left short diagonal
        gs = new GameSet();
        gs.addToSet(positions[29]);
        gs.addToSet(positions[38]);
        gs.addToSet(positions[41]);
        winning_sets.Add(gs);

        // 3 - bottom right short diagonal
        gs = new GameSet();
        gs.addToSet(positions[35]);
        gs.addToSet(positions[39]);
        gs.addToSet(positions[43]);
        winning_sets.Add(gs);

        // 5 - bottom row
        gs = new GameSet();
        gs.addToSet(positions[40]);
        gs.addToSet(positions[41]);
        gs.addToSet(positions[42]);
        gs.addToSet(positions[43]);
        gs.addToSet(positions[44]);
        winning_sets.Add(gs);
    }

}
