namespace Default
{
    public enum PlayerType
    {
        Fox,
        Crane,
        None,
    }
    public enum LightType
    {
        DayTime,
        EveningTime, 
        NightTime,
        EndTime
    }

    public enum CameraType
    {
        Side,
        Back
    }

    static class MapData
    {
        static public LightType currnetLight = LightType.DayTime;
        static public float zAxis = -2f;
    }

    static class PlayerData {
        static public string id; //프리펩 시작 할 경우 부여할거임
        static public PlayerType currentPlayer;
        static public bool isGrabTorch = false;
    }
}