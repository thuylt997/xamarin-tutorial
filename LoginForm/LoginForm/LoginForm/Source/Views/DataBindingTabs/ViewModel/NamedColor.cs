using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace LoginForm.Source.Views.DataBindingTabs.ViewModel
{
    public class NamedColor : IEquatable<NamedColor>, IComparable<NamedColor>
    {
        public string Name { get; private set; }

        public string FriendlyName { get; private set; }

        public Color Color { get; private set; }

        public string RgbDisplay { get; private set; }

        public static IList<NamedColor> All { get; private set; }

        public NamedColor() { }

        public int CompareTo(NamedColor other) => Name.CompareTo(other.Name);

        public bool Equals(NamedColor other) => Name.Equals(other.Name);

        static NamedColor()
        {
            List<NamedColor> all = new List<NamedColor>();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo fieldInfo in typeof(Color).GetRuntimeFields())
            {
                if (fieldInfo.IsPublic && fieldInfo.IsStatic && fieldInfo.FieldType == typeof(Color))
                {
                    // Convert the name to friendly name
                    string name = fieldInfo.Name;

                    stringBuilder.Clear();

                    int index = 0;

                    foreach (char ch in name)
                    {
                        if (index != 0 && Char.IsUpper(ch))
                        {
                            stringBuilder.Append(' ');
                        }

                        stringBuilder.Append(ch);
                        index++;
                    }

                    // Instantiate a NamedColor object.
                    Color color = (Color)fieldInfo.GetValue(null);

                    NamedColor namedColor = new NamedColor
                    {
                        Name = name,
                        FriendlyName = stringBuilder.ToString(),
                        Color = color,
                        RgbDisplay = String.Format("{0:X2}-{1:X2}-{2:X2}",
                                                    (int)(255 * color.R),
                                                    (int)(255 * color.G),
                                                    (int)(255 * color.B))
                    };

                    // Add it to the collection
                    all.Add(namedColor);
                }
            }

            all.TrimExcess();
            all.Sort();
            All = all;
        }

        public static string GetNearestColorName(Color color)
        {
            double shortestDistance = 1000;
            NamedColor closestColor = null;

            foreach (NamedColor namedColor in NamedColor.All)
            {
                double distance = Math.Sqrt(
                    Math.Pow(color.R - namedColor.Color.R, 2) +
                    Math.Pow(color.G - namedColor.Color.G, 2) +
                    Math.Pow(color.B - namedColor.Color.B, 2)
                );

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestColor = namedColor;
                }
            }

            return closestColor.Name;
        }

        public static NamedColor Find(string name) => ((List<NamedColor>)All).Find(nc => nc.Name == name);
    }
}
