using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class  EstadoController 
{
	public static EstadoController jugadorActual;



	private static string score;
	private static string record;
	private static string playerName;
	private static string playerId;

	private EstadoController() { }

	public static EstadoController GetInstance()
	{
		if (jugadorActual == null)
		{
			jugadorActual = new EstadoController();
			//DontDestroyOnLoad(gameObject);
		}
		return jugadorActual;
		/*else if(jugadorActual != this){
			
			Destroy(gameObject);
		}*/
	}



    
    public static void SetScore(string _score)
    {
	    score = _score;
    }

	public static string GetScore()
    {
		return (score != null) ? score : "0";
    }




	public static void SetRecord(string _record)
	{
	    record = _record;
	}

	public static string GetRecord()
	{
		return (record != null) ?record : "0";
	}


	public static void SetId(string _id)
	{
		playerId = _id;
	}

	public static string GetId()
	{
		return (playerId != null) ? playerId : "";
	}




	public static void SetNamePlayer(string _name)
	{
		playerName = _name;
	}

	public static string GetNamePlayer()
	{
		return (playerName != null) ? playerName : "";
	}


}



