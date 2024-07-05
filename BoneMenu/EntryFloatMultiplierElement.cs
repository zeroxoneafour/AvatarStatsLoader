using BoneLib.BoneMenu.Elements;
using MelonLoader;
using UnityEngine;

namespace AvatarStatsLoader.BoneMenu
{
    public class EntryFloatMultiplierElement : MenuElement
    {
        protected readonly MelonPreferences_Entry<float> entry;
        protected readonly float multiplier;

        public EntryFloatMultiplierElement(string name, Color color, MelonPreferences_Entry<float> entry, float multiplier) : base(name, color)
        {
            this.entry = entry;
            this.multiplier = multiplier;
        }

        public override ElementType Type => ElementType.Value;

        public float GetValue()
        {
            return entry.Value;
        }

        public void SetValue(float value)
        {
            entry.Value = value;
        }

        public override string DisplayValue => "x" + multiplier.ToString();

        public override void OnSelectLeft()
        {
            entry.Value *= multiplier;
        }

        public override void OnSelectRight()
        {
            entry.Value /= multiplier;
        }
    }
}
