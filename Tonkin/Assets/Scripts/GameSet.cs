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
}
