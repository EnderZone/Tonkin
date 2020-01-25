using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet {
    public ISet<BoardPosition> bp_set = new HashSet<BoardPosition>();

    public void addToSet(BoardPosition bp)
    {
        bp_set.Add(bp);
    }

    public ISet<BoardPosition> getSet()
    {
        return bp_set;
    }

    public int checkWinner()
    {
        int p1 = 0;
        int p2 = 0;
        int total = bp_set.Count;
        foreach (BoardPosition bp in bp_set)
        {
            switch (bp.getPlayer())
            {
                case 1:
                    p1++;
                    break;
                case 2:
                    p2++;
                    break;
                default:
                    break;
            }
        }

        if (p1 == total)
            return 1;
        if (p2 == total)
            return 2;
        return -1;
    }
}
