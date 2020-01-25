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

    private int blue_turn = 0;
    private int red_turn = 0;

    private GamePiece selectedPiece = null;

    public int turnOrder = 1;

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
        int winner = checkWinner();
        if (winner != -1)
        {
            displayWinner(winner);
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleMouseClickEvent();
            }
            UpdateTextPrompts();
        }
    }

    private void displayWinner(int winner)
    {
        Transform canvas = transform.GetChild(0);
        UnityEngine.UI.Text blue_turn_text = canvas.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text red_turn_text = canvas.GetChild(1).GetComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text blue_win_text = canvas.GetChild(2).GetComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text red_win_text = canvas.GetChild(3).GetComponent<UnityEngine.UI.Text>();


        blue_turn_text.text = "";
        red_turn_text.text = "";

        if (winner == 1)
        {
            blue_win_text.text = "Blue Player Wins";
        }
        else
        {
            red_win_text.text = "Red Player Wins";
        }
    }

    private void UpdateTextPrompts()
    {
        Transform canvas = transform.GetChild(0);
        UnityEngine.UI.Text blue_turn_text = canvas.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        UnityEngine.UI.Text red_turn_text = canvas.GetChild(1).GetComponent<UnityEngine.UI.Text>();

        if (turnOrder == 1)
        {
            blue_turn_text.text = "Blue Player Turn";
            red_turn_text.text = "";
        }
        else
        {
            blue_turn_text.text = "";
            red_turn_text.text = "Red Player Turn";
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
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("OpenSpot")))
            {
                moveSelectedPiece(hit.transform.GetComponent<GamePiece>().board_position);
            }
        }

        if (selectedPiece == null)
        {
            if (currentPiece != null && currentPiece.player == turnOrder)
            {
                selectedPiece = currentPiece;
                selectedPiece.SelectPiece();
                addPossiblePositions();
            }
        }
        else if (selectedPiece == currentPiece)
        {
            selectedPiece.SelectPiece();
            selectedPiece = null;
            removePossiblePositions();
        }
    }

    private void addPossiblePositions()
    {
        if (selectedPiece == null)
            return;

        if (selectedPiece.board_position == -1)
        {
            foreach (BoardPosition bp in positions)
            {
                if (bp.getPlayer() == 0)
                {
                    GameObject go = Instantiate(openSpotPrefab) as GameObject;
                    go.transform.SetParent(transform);

                    GamePiece p = go.GetComponent<GamePiece>();
                    possiblePositions.Add(p);
                    p.transform.position = bp.getTransformPosition();
                    p.board_position = bp.id;

                    possiblePositions.Add(p);
                }
            }
        }
        else
        {
            ISet<int> neighbours = positions[selectedPiece.board_position].getNeighbours();
            foreach (int pos in neighbours)
            {
                if (positions[pos].getPlayer() == 0)
                {
                    GameObject go = Instantiate(openSpotPrefab) as GameObject;
                    go.transform.SetParent(transform);

                    GamePiece p = go.GetComponent<GamePiece>();
                    possiblePositions.Add(p);
                    p.transform.position = positions[pos].getTransformPosition();
                    p.board_position = positions[pos].id;

                    possiblePositions.Add(p);
                }
            }
        }
    }

    private void removePossiblePositions()
    {
        foreach (GamePiece gp in possiblePositions)
        {
            Destroy(gp.gameObject);
        }
        possiblePositions.Clear();
    }

    private void moveSelectedPiece(int pos)
    {
        if (selectedPiece.board_position != -1)
        {
            positions[selectedPiece.board_position].setPlayer(0);
        }

        selectedPiece.board_position = pos;
        selectedPiece.transform.position = positions[pos].getTransformPosition();
        positions[pos].setPlayer(selectedPiece.player);

        removePossiblePositions();
        selectedPiece.isSelected = false;
        selectedPiece = null;

        turnOrder = (turnOrder == 1) ? 2 : 1;
    }

    private int checkWinner()
    {
        foreach (GameSet gs in winning_sets)
        {
            int winner = gs.checkWinner();
            if (winner != -1)
                return winner;
        }
        return -1;
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
        p.board_position = -1;
        p.player = (x < 10) ? 1 : 2;
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
        gs.addToSet(positions[9]);
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
