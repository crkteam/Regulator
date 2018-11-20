using UnityEngine;

public class JsonPlayer : BaseJson
{
    private Player player;

    public JsonPlayer()
    {
       player = new Player();
        if (!check("MyPlayer"))
            setAll(0,0,0);
    }

    public int getStage()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);  //將json轉入player

        return player.stage;
    }

    public int getLobby()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.lobby;
    }
    
    public int getDialogue()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player.dialogue;
    }
    
    public Player getAll()
    {
        string data = load("MyPlayer");
        player = JsonUtility.FromJson<Player>(data);

        return player;
    }

    public void setAll(int lobby,int stage,int dialogue)
    {
        player.lobby = lobby;
        player.stage = stage;
        player.dialogue = dialogue;
                
        save(player,"MyPlayer");
    }
}