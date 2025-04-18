using System;
using System.Drawing;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.Linq;

namespace ExileMaps.Classes
{
    public class Map : INotifyPropertyChanged
    {
        private Color nameColor = Color.FromArgb(255, 255, 255, 255);
        private Color backgroundColor = Color.FromArgb(220, 0, 0, 0);
        private Color nodeColor = Color.FromArgb(200, 155, 155, 155);
        private bool drawLine = false;
        private bool highlight = true;
        
        [JsonIgnore]
        private int count = 0;

        [JsonIgnore]
        private int lockedCount = 0;

        [JsonIgnore]
        private int fogCount = 0;
        private float weight = 1.0f;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name { get; set; } = "";

        [JsonIgnore]
        public string ID { get; set; } = ""; // deprecated, here so peoples imported settings dont break immediately

        public string[] IDs { get; set; } = [];
        public string ShortestId { get; set; }
        public string[] Biomes { get; set; } = [];

        public bool IsTower() {
            return MatchID("MapSwampTower") || MatchID("MapLostTowers") || MatchID("MapMesa") || MatchID("MapBluff") || MatchID("MapAlpineRidge");
        }

        public override string ToString()
        {
            return Name;
        }

        public bool MatchID(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            return Array.Exists(IDs, x => x.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public string BiomesToString() {
            if (Biomes.Length == 0) return "None";
            return string.Join(", ", Biomes.Where(x => !string.IsNullOrWhiteSpace(x)));
        }
        
        [JsonConverter(typeof(JsonColorConverter))]
        public Color NameColor
        {
            get => nameColor;
            set
            {
                if (nameColor != value)
                {
                    nameColor = value;
                    OnPropertyChanged(nameof(NameColor));
                }
            }
        }

        [JsonConverter(typeof(JsonColorConverter))]
        public Color BackgroundColor
        {
            get => backgroundColor;
            set
            {
                if (backgroundColor != value)
                {
                    backgroundColor = value;
                    OnPropertyChanged(nameof(BackgroundColor));
                }
            }
        }

        [JsonConverter(typeof(JsonColorConverter))]
        public Color NodeColor
        {
            get => nodeColor;
            set
            {
                if (nodeColor != value)
                {
                    nodeColor = value;
                    OnPropertyChanged(nameof(NodeColor));
                }
            }
        }

        public bool DrawLine
        {
            get => drawLine;
            set
            {
                if (drawLine != value)
                {
                    drawLine = value;
                    OnPropertyChanged(nameof(DrawLine));
                }
            }
        }

        public bool Highlight
        {
            get => highlight;
            set
            {
                if (highlight != value)
                {
                    highlight = value;
                    OnPropertyChanged(nameof(Highlight));
                }
            }
        }

        public int Count
        {
            get => count;
            set
            {
                if (count != value)
                {
                    count = value;
                    OnPropertyChanged(nameof(Count));
                }
            }
        }

        public int LockedCount
        {
            get => lockedCount;
            set
            {
                if (lockedCount != value)
                {
                    lockedCount = value;
                    OnPropertyChanged(nameof(LockedCount));
                }
            }
        } 

        public int FogCount
        {
            get => fogCount;
            set
            {
                if (fogCount != value)
                {
                    fogCount = value;
                    OnPropertyChanged(nameof(FogCount));
                }
            }
        }

        public float Weight
        {
            get => weight;
            set
            {
                if (weight != value)
                {
                    weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }
    }
}
