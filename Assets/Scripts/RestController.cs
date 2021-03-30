using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEditor;

public class RestController
{

    private const string URL = "https://animals-c205c.firebaseio.com";

    public delegate void GetUserCallback(User user);
    public static void SaveUser(string userId, User newUser)
    {
        RestClient.Put(URL + "/users/" + userId + ".json", newUser);
    }



  public static User GetUser(string id)
    {

       User player = new User();
       RestClient.Get<User>("https://animals-c205c.firebaseio.com" + "/users/" + id + ".json").Then( response => 
       {
        
           player =  response; 
       });

        
        return player;
    }
        
       


}
