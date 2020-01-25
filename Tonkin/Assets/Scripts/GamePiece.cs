using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour {
    public float selected_offset = 0.4f;
    public int board_position = -1;
    public int player;

    public bool isSelected;


    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    public void SelectPiece()
    {
        if (isSelected)
        {
            transform.position += Vector3.down * selected_offset;
        }
        else
        {
            transform.position += Vector3.up * selected_offset;
        }

        isSelected = !isSelected;
    }
}
