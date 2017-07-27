using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ScoreContext : IComparable<ScoreContext>
{

    public int id;
    public int score;
    public Color color;
 
    public ScoreContext(int id, int score, Color color)
    {
        this.id = id;
        this.score = score;
        this.color = color;
    }

    public int CompareTo(ScoreContext other)
    {
        //return other.score - score - (10 * id);
        if (other.score > this.score)
        {
            return 1;
        }
        else if (other.score == this.score) {
            return 0;
        }
        else
        {
            return -1;

        }
    }

}
