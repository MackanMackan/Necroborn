using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easings
{
    public enum Easing
    {
        EaseInSine, EaseOutSine, EaseInOutSine,
        EaseInQuad, EaseOutQuad, EaseInOutQuad,
        EaseInCubic, EaseOutCubic, EaseInOutCubic,
        EaseInQuart, EaseOutQuart, EaseInOutQuart,
        EaseInQuint, EaseOutQuint, EaseInOutQuint,
        EaseInExpo, EaseOutExpo, EaseInOutExpo,
        EaseInCirc, EaseOutCirc, EaseInOutCirc,
        EaseInBack, EaseOutBack, EaseInOutBack,
        EaseInElastic, EaseOutElastic, EaseInOutElastic,
        EaseInBounce, EaseOutBounce, EaseInOutBounce
    }
    const float c1 = 1.70158f;
    const float c2 = c1 + 1;
    const float c3 = (2 * MathF.PI) / 3;
    const float c4 = (2 * MathF.PI) / 4.5f;
    const float n1 = 7.5625f;
    const float d1 = 2.75f;
    public static float GetEasing(Easings.Easing easing, float time, float magnitude = 1f, float timeSacle = 1)
    {
        float easingValue = 0;
        time = time * timeSacle;
        switch (easing)
        {
            case Easing.EaseInSine: easingValue = 1 - MathF.Cos((time * MathF.PI) / 2); break;
            case Easing.EaseOutSine: easingValue = MathF.Sin((time * MathF.PI) / 2); break;
            case Easing.EaseInOutSine: easingValue = -(MathF.Cos(MathF.PI * time) - 1) / 2; break;
            case Easing.EaseInQuad: easingValue = time * time; break;
            case Easing.EaseOutQuad: easingValue = 1 - (1 - time) * (1 - time); break;
            case Easing.EaseInOutQuad: easingValue = time < 0.5 ? 2 * time * time : 1 - MathF.Pow(-2 * time + 2, 2) / 2; break;
            case Easing.EaseInCubic: easingValue = time * time * time; break;
            case Easing.EaseOutCubic: easingValue = 1 - MathF.Pow(1 - time, 3); break;
            case Easing.EaseInOutCubic: easingValue = time < 0.5 ? 4 * time * time * time : 1 - MathF.Pow(-2 * time + 2, 3) / 2; break;
            case Easing.EaseInQuart: easingValue = time * time * time * time; break;
            case Easing.EaseOutQuart: easingValue = 1 - MathF.Pow(1 - time, 4); break;
            case Easing.EaseInOutQuart: easingValue = time < 0.5 ? 8 * time * time * time * time : 1 - MathF.Pow(-2 * time + 2, 4) / 2; break;
            case Easing.EaseInExpo: easingValue = time == 0 ? 0 : MathF.Pow(2, 10 * time - 10); break;
            case Easing.EaseOutExpo: easingValue = time == 1 ? 1 : 1 - MathF.Pow(2, -10 * time); break;
            case Easing.EaseInOutExpo: easingValue = time == 0 ? 0 : time == 1 ? 1
                                        : time < 0.5 ? MathF.Pow(2, 20 * time - 10) / 2
                                        : (2 - MathF.Pow(2, -20 * time + 10)) / 2; break;
            case Easing.EaseInCirc: easingValue = 1 - MathF.Sqrt(1 - MathF.Pow(time, 2)); break;
            case Easing.EaseOutCirc: easingValue = MathF.Sqrt(1 - MathF.Pow(time - 1, 2)); break;
            case Easing.EaseInOutCirc: easingValue = time < 0.5
                                        ? (1 - MathF.Sqrt(1 - MathF.Pow(2 * time, 2))) / 2
                                        : (MathF.Sqrt(1 - MathF.Pow(-2 * time + 2, 2)) + 1) / 2; break;
            case Easing.EaseInBack: easingValue = c2 * time * time * time - c1 * time * time; break;
            case Easing.EaseOutBack: easingValue = 1 + c2 * MathF.Pow(time - 1, 3) + c1 * MathF.Pow(time - 1, 2); break;
            case Easing.EaseInOutBack: easingValue = time < 0.5
                                         ? (MathF.Pow(2 * time, 2) * ((c2 + 1) * 2 * time - c2)) / 2
                                         : (MathF.Pow(2 * time - 2, 2) * ((c2 + 1) * (time * 2 - 2) + c2) + 2) / 2; break;
            case Easing.EaseInElastic: easingValue = time == 0 ? 0 : time == 1 ? 1
                                         : -MathF.Pow(2, 10 * time - 10) * MathF.Sin((time * 10 - 10.75f) * c3); break;
            case Easing.EaseOutElastic: easingValue = time == 0 ? 0 : time == 1 ? 1
                                                     : MathF.Pow(2, -10 * time) * MathF.Sin((time * 10 - 0.75f) * c3) + 1; ; break;
            case Easing.EaseInOutElastic: easingValue = time == 0 ? 0 : time == 1 ? 1 : time < 0.5
                                                      ? -(MathF.Pow(2, 20 * time - 10) * MathF.Sin((20 * time - 11.125f) * c4)) / 2
                                                      : (MathF.Pow(2, -20 * time + 10) * MathF.Sin((20 * time - 11.125f) * c4)) / 2 + 1; break;
            case Easing.EaseInBounce: easingValue = 1 - GetEasing(Easing.EaseOutBounce, 1 - time); break;
            case Easing.EaseOutBounce:
                if (time < 1 / d1)
                {
                    easingValue = n1 * time * time;
                }
                else if (time < 2 / d1)
                {
                    easingValue = n1 * (time -= 1.5f / d1) * time + 0.75f;
                }
                else if (time < 2.5 / d1)
                {
                    easingValue = n1 * (time -= 2.25f / d1) * time + 0.9375f;
                }
                else
                {
                    easingValue = n1 * (time -= 2.625f / d1) * time + 0.984375f;
                }
                break;
            case Easing.EaseInOutBounce: easingValue = time < 0.5
                                          ? (1 - GetEasing(Easing.EaseOutBounce, 1 - 2 * time)) / 2
                                          : (1 + GetEasing(Easing.EaseOutBounce, 2 * time - 1)) / 2; 
                break;
            default: return 0;
        }
        return easingValue * magnitude;
    }
}
