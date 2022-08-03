using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PorchaAPI
{
    public partial class Task: INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _textTask;
        public string TextTask
        {
            get { return _textTask; }
            set { _textTask = value; OnPropertyChanged(); }
        }
        public DateTime? DateTask { get; set; }
        public int? Priority { get; set; }
        public int? IdPostman { get; set; }
        public int? StatusTask { get; set; }

        public virtual User IdPostmanNavigation { get; set; }
        public virtual StatusTask StatusTaskNavigation { get; set; }



        private Visibility _textBoxVisibility = Visibility.Collapsed;

        public Visibility TextBoxVisibility { get => _textBoxVisibility; set { _textBoxVisibility = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
