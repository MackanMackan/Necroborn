
using UnityEngine;

namespace _Scripts.Extensions
{
    public static class MathX
    {
        public static float Squared(this float value)
        {
            return value * value;
        }

        /// <summary>
        /// Return a positive normalized value.
        /// </summary>
        /// <param name="value">value to be used</param>
        /// <param name="maxValue">Value to be normalized against</param>
        public static float Normalize(float value, float maxValue)
        {
            return Mathf.Abs(value / maxValue);
        }

        public static float Remap(float value, float low1, float high1, float low2, float high2) {
            return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
        }

        public static float RemapClamped(float value, float low1, float high1, float low2, float high2) {
            return Mathf.Clamp(Remap(value, low1, high1, low2, high2), low2, high2);
        }
    }
}
