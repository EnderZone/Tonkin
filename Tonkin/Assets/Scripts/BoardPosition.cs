using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPosition {
    public int id;
    private int player;
    private Vector3 position;

    public ISet<int> neighbours;

    // Start is called before the first frame update
    public BoardPosition(int position)
    {
        player = 0;
        neighbours = new HashSet<int>();
        setPosition(position);
    }

    public void setPlayer(int p)
    {
        player = p;
    }

    public int getPlayer()
    {
        return player;
    }

    public ISet<int> getNeighbours()
    {
        return neighbours;
    }

    public Vector3 getTransformPosition()
    {
        return position;
    }

    public void setPosition(int board_pos)
    {
        Vector3 new_pos;
        id = board_pos;
        switch (board_pos)
        {
            case 0:
                new_pos = new Vector3(4.2f, 0.0f, 4.2f);
                neighbours.Add(1);
                neighbours.Add(5);
                neighbours.Add(9);
                break;
            case 1:
                new_pos = new Vector3(4.2f, 0.0f, 2.1f);
                neighbours.Add(0);
                neighbours.Add(2);
                neighbours.Add(5);
                neighbours.Add(7);
                break;
            case 2:
                new_pos = new Vector3(4.2f, 0.0f, 0.0f);
                neighbours.Add(1);
                neighbours.Add(3);
                neighbours.Add(7);
                neighbours.Add(8);
                neighbours.Add(12);
                break;
            case 3:
                new_pos = new Vector3(4.2f, 0.0f, -2.1f);
                neighbours.Add(2);
                neighbours.Add(4);
                neighbours.Add(6);
                neighbours.Add(8);
                break;
            case 4:
                new_pos = new Vector3(4.2f, 0.0f, -4.2f);
                neighbours.Add(3);
                neighbours.Add(6);
                neighbours.Add(15);
                break;
            case 5:
                new_pos = new Vector3(3.15f, 0.0f, 3.15f);
                neighbours.Add(0);
                neighbours.Add(1);
                neighbours.Add(9);
                neighbours.Add(10);
                break;
            case 6:
                new_pos = new Vector3(3.15f, 0.0f, -3.15f);
                neighbours.Add(3);
                neighbours.Add(4);
                neighbours.Add(14);
                neighbours.Add(15);
                break;
            case 7:
                new_pos = new Vector3(2.8f, 0.0f, 1.4f);
                neighbours.Add(1);
                neighbours.Add(2);
                neighbours.Add(10);
                neighbours.Add(11);
                break;
            case 8:
                new_pos = new Vector3(2.8f, 0.0f, -1.4f);
                neighbours.Add(2);
                neighbours.Add(3);
                neighbours.Add(13);
                neighbours.Add(14);
                break;
            case 9:
                new_pos = new Vector3(2.1f, 0.0f, 4.2f);
                neighbours.Add(0);
                neighbours.Add(5);
                neighbours.Add(16);
                neighbours.Add(20);
                break;
            case 10:
                new_pos = new Vector3(2.1f, 0.0f, 2.1f);
                neighbours.Add(5);
                neighbours.Add(7);
                neighbours.Add(11);
                neighbours.Add(16);
                neighbours.Add(18);
                neighbours.Add(22);
                break;
            case 11:
                new_pos = new Vector3(2.1f, 0.0f, 1.05f);
                neighbours.Add(7);
                neighbours.Add(10);
                neighbours.Add(12);
                neighbours.Add(22);
                break;
            case 12:
                new_pos = new Vector3(2.1f, 0.0f, 0.0f);
                neighbours.Add(2);
                neighbours.Add(11);
                neighbours.Add(13);
                neighbours.Add(22);
                break;
            case 13:
                new_pos = new Vector3(2.1f, 0.0f, -1.05f);
                neighbours.Add(8);
                neighbours.Add(12);
                neighbours.Add(14);
                neighbours.Add(22);
                break;
            case 14:
                new_pos = new Vector3(2.1f, 0.0f, -2.1f);
                neighbours.Add(6);
                neighbours.Add(8);
                neighbours.Add(13);
                neighbours.Add(17);
                neighbours.Add(19);
                neighbours.Add(22);
                break;
            case 15:
                new_pos = new Vector3(2.1f, 0.0f, -4.2f);
                neighbours.Add(4);
                neighbours.Add(6);
                neighbours.Add(17);
                neighbours.Add(25);
                break;
            case 16:
                new_pos = new Vector3(1.4f, 0.0f, 2.8f);
                neighbours.Add(9);
                neighbours.Add(10);
                neighbours.Add(18);
                neighbours.Add(20);
                break;
            case 17:
                new_pos = new Vector3(1.4f, 0.0f, -2.8f);
                neighbours.Add(14);
                neighbours.Add(15);
                neighbours.Add(19);
                neighbours.Add(24);
                break;
            case 18:
                new_pos = new Vector3(1.05f, 0.0f, 2.1f);
                neighbours.Add(10);
                neighbours.Add(16);
                neighbours.Add(21);
                neighbours.Add(22);
                break;
            case 19:
                new_pos = new Vector3(1.05f, 0.0f, -2.1f);
                neighbours.Add(14);
                neighbours.Add(17);
                neighbours.Add(22);
                neighbours.Add(23);
                break;
            case 20:
                new_pos = new Vector3(0.0f, 0.0f, 4.2f);
                neighbours.Add(9);
                neighbours.Add(16);
                neighbours.Add(21);
                neighbours.Add(27);
                neighbours.Add(29);
                break;
            case 21:
                new_pos = new Vector3(0.0f, 0.0f, 2.1f);
                neighbours.Add(18);
                neighbours.Add(20);
                neighbours.Add(22);
                neighbours.Add(25);
                break;
            case 22:
                new_pos = new Vector3(0.0f, 0.0f, 0.0f);
                neighbours.Add(10);
                neighbours.Add(11);
                neighbours.Add(12);
                neighbours.Add(13);
                neighbours.Add(14);
                neighbours.Add(18);
                neighbours.Add(19);
                neighbours.Add(21);
                neighbours.Add(23);
                neighbours.Add(25);
                neighbours.Add(26);
                neighbours.Add(30);
                neighbours.Add(31);
                neighbours.Add(32);
                neighbours.Add(33);
                neighbours.Add(34);
                break;
            case 23:
                new_pos = new Vector3(0.0f, 0.0f, -2.1f);
                neighbours.Add(19);
                neighbours.Add(22);
                neighbours.Add(24);
                neighbours.Add(26);
                break;
            case 24:
                new_pos = new Vector3(0.0f, 0.0f, -4.2f);
                neighbours.Add(15);
                neighbours.Add(17);
                neighbours.Add(23);
                neighbours.Add(28);
                neighbours.Add(35);
                break;
            case 25:
                new_pos = new Vector3(-1.05f, 0.0f, 2.1f);
                neighbours.Add(21);
                neighbours.Add(22);
                neighbours.Add(27);
                neighbours.Add(30);
                break;
            case 26:
                new_pos = new Vector3(-1.05f, 0.0f, -2.1f);
                neighbours.Add(22);
                neighbours.Add(23);
                neighbours.Add(28);
                neighbours.Add(34);
                break;
            case 27:
                new_pos = new Vector3(-1.4f, 0.0f, 2.8f);
                neighbours.Add(20);
                neighbours.Add(25);
                neighbours.Add(29);
                neighbours.Add(30);
                break;
            case 28:
                new_pos = new Vector3(-1.4f, 0.0f, -2.8f);
                neighbours.Add(22);
                neighbours.Add(26);
                neighbours.Add(34);
                neighbours.Add(35);
                break;
            case 29:
                new_pos = new Vector3(-2.1f, 0.0f, 4.2f);
                neighbours.Add(20);
                neighbours.Add(27);
                neighbours.Add(38);
                neighbours.Add(40);
                break;
            case 30:
                new_pos = new Vector3(-2.1f, 0.0f, 2.1f);
                neighbours.Add(22);
                neighbours.Add(25);
                neighbours.Add(27);
                neighbours.Add(31);
                neighbours.Add(36);
                neighbours.Add(38);
                break;
            case 31:
                new_pos = new Vector3(-2.1f, 0.0f, 1.05f);
                neighbours.Add(22);
                neighbours.Add(30);
                neighbours.Add(31);
                neighbours.Add(36);
                break;
            case 32:
                new_pos = new Vector3(-2.1f, 0.0f, 0.0f);
                neighbours.Add(22);
                neighbours.Add(31);
                neighbours.Add(33);
                neighbours.Add(42);
                break;
            case 33:
                new_pos = new Vector3(-2.1f, 0.0f, -1.05f);
                neighbours.Add(22);
                neighbours.Add(32);
                neighbours.Add(34);
                neighbours.Add(37);
                break;
            case 34:
                new_pos = new Vector3(-2.1f, 0.0f, -2.1f);
                neighbours.Add(22);
                neighbours.Add(26);
                neighbours.Add(28);
                neighbours.Add(35);
                neighbours.Add(37);
                neighbours.Add(39);
                break;
            case 35:
                new_pos = new Vector3(-2.1f, 0.0f, -4.2f);
                neighbours.Add(24);
                neighbours.Add(28);
                neighbours.Add(39);
                neighbours.Add(44);
                break;
            case 36:
                new_pos = new Vector3(-2.8f, 0.0f, 1.4f);
                neighbours.Add(30);
                neighbours.Add(31);
                neighbours.Add(41);
                neighbours.Add(42);
                break;
            case 37:
                new_pos = new Vector3(-2.8f, 0.0f, -1.4f);
                neighbours.Add(33);
                neighbours.Add(34);
                neighbours.Add(42);
                neighbours.Add(43);
                break;
            case 38:
                new_pos = new Vector3(-3.15f, 0.0f, 3.15f);
                neighbours.Add(29);
                neighbours.Add(30);
                neighbours.Add(40);
                neighbours.Add(41);
                break;
            case 39:
                new_pos = new Vector3(-3.15f, 0.0f, -3.15f);
                neighbours.Add(34);
                neighbours.Add(35);
                neighbours.Add(43);
                neighbours.Add(44);
                break;
            case 40:
                new_pos = new Vector3(-4.2f, 0.0f, 4.2f);
                neighbours.Add(29);
                neighbours.Add(38);
                neighbours.Add(41);
                break;
            case 41:
                new_pos = new Vector3(-4.2f, 0.0f, 2.1f);
                neighbours.Add(36);
                neighbours.Add(38);
                neighbours.Add(40);
                neighbours.Add(42);
                break;
            case 42:
                new_pos = new Vector3(-4.2f, 0.0f, 0.0f);
                neighbours.Add(32);
                neighbours.Add(36);
                neighbours.Add(37);
                neighbours.Add(41);
                neighbours.Add(43);
                break;
            case 43:
                new_pos = new Vector3(-4.2f, 0.0f, -2.1f);
                neighbours.Add(37);
                neighbours.Add(39);
                neighbours.Add(42);
                neighbours.Add(44);
                break;
            case 44:
                new_pos = new Vector3(-4.2f, 0.0f, -4.2f);
                neighbours.Add(35);
                neighbours.Add(39);
                neighbours.Add(43);
                break;
            default:
                new_pos = new Vector3(0.0f, 0.0f, 0.0f);
                break;
        }
        position = new_pos;
    }
}
