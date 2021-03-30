using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public string name;
    public string score;

    public Player() { }

    public Player(string playername, string score)
    {
        this.name = playername;
        this.score = score;
    }
   

}
