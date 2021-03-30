using System;

[Serializable]
public class User 
{
    public string _email;
    public string _id;
    public string _name;
    public string _score;
    public string _record;


    public User()
    { }


    public User(string id, string username,string email,  string score, string record)
    {
        this._id = id;
        this._name = username;
        this._email = email;
        this._score = score;
        this._record = record;
    }

}
