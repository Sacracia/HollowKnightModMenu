namespace HollowKnightModMenu.UI
{
    abstract class BaseTab
    {
        public static BaseTab Instance { get; }
        public abstract string Name { get; set; }
        public abstract void DrawElements();
    }
}
