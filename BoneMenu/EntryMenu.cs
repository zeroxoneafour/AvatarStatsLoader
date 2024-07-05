using System;
using BoneLib.BoneMenu.Elements;
using BoneLib.BoneMenu.UI;
using MelonLoader;
using UnityEngine;

namespace AvatarStatsLoader.BoneMenu
{
    class EntryMenu
    {
        public readonly MenuCategory menu;
        public readonly EntryFloatElement value;
        public readonly EntryFloatMultiplierElement multiplyByTen;
        public readonly FunctionElement setToOne, loadFromAvatar, loadFromAvatarCalculated;

        public EntryMenu(MenuCategory parentMenu, string name, Func<float> getFromLoaded, MelonPreferences_Entry<float> entry)
        {
            menu = parentMenu.CreateCategory(name, "ffffff");
            value = menu.CreateEntryFloatElement("value", "ffffff", entry, 1f);
            multiplyByTen = menu.CreateEntryFloatMultiplierElement("ffffff", entry, 10f);
            setToOne = menu.CreateFunctionElement("Set to 1.0", "ffffff", () => {
                entry.Value = 1.0f;
            });
            loadFromAvatar = menu.CreateFunctionElement("Load from avatar's loaded value", "ffffff", () => {
                entry.Value = getFromLoaded.Invoke();
            });
            loadFromAvatarCalculated = menu.CreateFunctionElement("Load from avatar's computed value", "ffffff", () => {
                entry.ResetToDefault();
            });
            entry.OnEntryValueChanged.Subscribe((prev, cur) => refreshDisplayValue(), int.MaxValue);
        }

        //private readonly FieldInfo elementField = typeof(UIValueField).GetField("element", BindingFlags.NonPublic | BindingFlags.Instance);

        public void refreshDisplayValue()
        {
            foreach (UIValueField obj in GameObject.FindObjectsOfType<UIValueField>())
            {
                //if (elementField.GetValue(obj) == value)
                if (obj.NameText.text == value.Name)
                {
                    obj.SetText(value.Name, value.DisplayValue);
                }
            }
        }
    }
}
