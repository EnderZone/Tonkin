using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPosition : MonoBehaviour {
    private GamePiece playerPiece;

    public GameObject optionPrefab;

    public Vector3 position;
    public ISet<BoardPosition> neighbours;

    // Start is called before the first frame update
    void Start()
    {
        playerPiece = null;
        neighbours = new HashSet<BoardPosition>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPlayerPiece(GamePiece p)
    {
        playerPiece = p;
    }

    public GamePiece getPlayerPiece()
    {
        return playerPiece;
    }

    public void addNeighbour(BoardPosition bp)
    {
        neighbours.Add(bp);
    }

    public ISet<BoardPosition> getNeighbours()
    {
        return neighbours;
    }
}
