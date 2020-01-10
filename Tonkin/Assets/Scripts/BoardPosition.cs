using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPosition : MonoBehaviour {
    public GamePiece playerPiece;

    // Start is called before the first frame update
    void Start()
    {
        playerPiece = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPlayerPiece(GamePiece p)
    {
        playerPiece = p;
    }
}
