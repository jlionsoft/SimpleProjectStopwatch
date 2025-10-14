using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SimpleProjectStopwatch.Controls
{
    public partial class DateTimePicker : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));



        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(DateTime), typeof(DateTimePicker),
                new FrameworkPropertyMetadata(DateTime.Now, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));

        public DateTime Value
        {
            get => (DateTime)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public DateTime DatePart
        {
            get => Value.Date;
            set => Value = new DateTime(value.Year, value.Month, value.Day, Value.Hour, Value.Minute, Value.Second);
        }

        public int HourPart
        {
            get => Value.Hour;
            set => Value = new DateTime(Value.Year, Value.Month, Value.Day, value, Value.Minute, Value.Second);
        }

        public int MinutePart
        {
            get => Value.Minute;
            set => Value = new DateTime(Value.Year, Value.Month, Value.Day, Value.Hour, value, Value.Second);
        }

        public int SecondPart
        {
            get => Value.Second;
            set => Value = new DateTime(Value.Year, Value.Month, Value.Day, Value.Hour, Value.Minute, value);
        }

        public IEnumerable<int> Hours => Enumerable.Range(0, 24);
        public IEnumerable<int> Minutes => Enumerable.Range(0, 60);
        public IEnumerable<int> Seconds => Enumerable.Range(0, 60);

        public DateTimePicker()
        {
            InitializeComponent();
            //DataContext = this;
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (DateTimePicker)d;
            control.OnPropertyChanged(nameof(DatePart));
            control.OnPropertyChanged(nameof(HourPart));
            control.OnPropertyChanged(nameof(MinutePart));
            control.OnPropertyChanged(nameof(SecondPart));
        }

    }
}