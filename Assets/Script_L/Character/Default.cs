namespace Default
{
    public enum PlayerType
    {
        Fox,
        Crane,
        None,
    }

    static class PlayerData {
        static public string id; //프리펩 시작 할 경우 부여할거임
        static public PlayerType currentPlayer;
    }
}