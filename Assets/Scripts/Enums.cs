namespace Game
{
    public enum Scenes
    {
        START_SCENE,
        LEVEL_SCENE,
        GAMEOVER_SCENE
    }

    public enum StateType
    {
        START,
        LEVEL,
        GAMEOVER
    }

    public enum PlatformSizeChangeType
    {
        NONE,
        WIDTH_CHANGE,
        LENGTH_CHANGE,
        DEPTH_CHANGE,
        UNIFORM_CHANGE
    }

    public enum PlatformMovingDirection
    {
        NONE,
        HORIZONTAL,
        VERTICAL,
        Z_AXIS
    }

    public enum PlayerState
    {
        MOVING,
        FALLING,
        STANDING,
        DEAD
    }

}
