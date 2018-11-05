using UnityEngine;

public class JsonPlayer : BaseJson
{
    private Player player;

    public JsonPlayer()
    {
       player = new Player();
        if (!check("MyPlayer"))
            setAll(0,0);
    }

    public int getStage()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.stage;
    }

    public int getLobby()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.lobby;
    }
    
    public Player getAll()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player;
    }

    public void setAll(int lobby,int stage)
    {
        player.lobby = lobby;
        player.stage = stage;
                
        save(player,"MyPlayer");
    }
}