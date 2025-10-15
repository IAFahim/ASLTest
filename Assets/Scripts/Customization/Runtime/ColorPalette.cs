using UnityEngine;

namespace Customization.Runtime
{
    [CreateAssetMenu(fileName = "ColorPalette", menuName = "Customization/New ColorPalettes", order = 0)]
    public class ColorPalette : ScriptableObject
    {
        public Color[] colors = new Color[] // AI Color Palette
        {
            new Color(0.96f, 0.41f, 0.38f),   // Vibrant Red
            new Color(0.38f, 0.71f, 0.96f),   // Sky Blue
            new Color(0.56f, 0.93f, 0.56f),   // Mint Green
            new Color(0.98f, 0.75f, 0.31f),   // Warm Orange
            new Color(0.65f, 0.34f, 0.85f),   // Purple
            new Color(0.98f, 0.39f, 0.76f),   // Pink
            new Color(0.27f, 0.85f, 0.85f),   // Teal
            new Color(0.95f, 0.61f, 0.07f),   // Gold
            new Color(0.47f, 0.53f, 0.60f),   // Slate Gray
            new Color(0.98f, 0.90f, 0.68f)    // Soft Yellow
        };
    }
}