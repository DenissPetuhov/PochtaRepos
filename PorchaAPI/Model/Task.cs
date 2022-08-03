using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

#nullable disable

namespace PorchaAPI
{
    public partial class Task: INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string TextTask { get; set; }
        public DateTime? DateTask { get; set; }
        public int? Priority { get; set; }
        public int? IdPostman { get; set; }
        public int? StatusTask { get; set; }

        public virtual User IdPostmanNavigation { get; set; }
        [JsonIgnore]
        public virtual StatusTask StatusTaskNavigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}

