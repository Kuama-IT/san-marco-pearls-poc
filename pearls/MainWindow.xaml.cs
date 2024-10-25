using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using CookComputing.XmlRpc;
using pearls.ProxyClient;

namespace pearls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private IPearlXmlRpcClient _proxyConnector;
        private string _errors;

        public string Errors
        {
            get => _errors;
            set
            {
                if (_errors != value)
                {
                    _errors = value;
                    OnPropertyChanged(nameof(Errors));
                }
            }
        }

        private string _data;
        private string _license;

        public string Data
        {
            get => _data;
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged(nameof(Data));
                }
            }
        }


        public string License
        {
            get => _license;
            set
            {
                if (_license != value)
                {
                    _license = value;
                    OnPropertyChanged(nameof(License));
                }
            }
        }

        private string _command = "";

        public string Command
        {
            get => _command;
            set
            {
                if (_command != value)
                {
                    _command = value;
                    OnPropertyChanged(nameof(Command));
                }
            }
        }

        private string _colorantName = "";

        public string ColorantName
        {
            get => _colorantName;
            set
            {
                if (_colorantName != value)
                {
                    _colorantName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedPort = "COM3";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _proxyConnector = XmlRpcProxyGen.Create<IPearlXmlRpcClient>();
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            string[] portNames = SerialPort.GetPortNames();
            ComboBoxPorts.ItemsSource = portNames;
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            try
            {
                Errors = "";
                Data = "";
                const string address = "0002";
                const int baudRate = 19200;
                Command = $"Connect port {_selectedPort} - address {address} - baudRate {baudRate}";
                _proxyConnector.Connect(_selectedPort, address, baudRate, "");
            }
            catch (Exception ex)
            {
                Errors = $"C# exception: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void ProtectionStatus(object sender, RoutedEventArgs e)
        {
            Errors = "";
            Data = "";
            Command = "Protection status";
            try
            {
                var res = _proxyConnector.ProtectionStatus();
                Errors = res.Error;
                Data = res.Data.ToString();
            }
            catch (Exception ex)
            {
                Errors = $"C# exception: {ex.Message}";
            }
        }

        private void ReadUnits(object sender, RoutedEventArgs e)
        {
            Errors = "";
            Data = "";
            Command = "Read units";
            try
            {
                var res = _proxyConnector.ReadDispenserUnitConfig(1);
                Errors = res.Error;
                Data = res.Data;
            }
            catch (Exception ex)
            {
                Errors = $"C# exception: {ex.Message}";
            }
        }

        private void GetNumberOfDispenserUnits(object sender, RoutedEventArgs e)
        {
            Errors = "";
            Data = "";
            Command = "Get Number of dispenser units";
            try
            {
                var res = _proxyConnector.GetNumberOfDispenserUnits();
                Errors = res.Error;
                Data = string.Join(" ", res.Data);
            }
            catch (Exception ex)
            {
                Errors = $"C# exception: {ex.Message}";
            }
        }

        private void ActivateLicense(object sender, RoutedEventArgs e)
        {
            Errors = "";
            Data = "";
            Command = $"Activate license: {License}";
            try
            {
                var res = _proxyConnector.Activate(License);
                Errors = res.Error;
                Data = $"{res.Data}";
            }
            catch (Exception ex)
            {
                Errors = $"C# exception: {ex.Message}";
            }
        }

        private void ComboBoxPorts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedPort = ComboBoxPorts.SelectedItem as string;
        }

        private void GetFillLevel(object sender, RoutedEventArgs e)
        {
            Errors = "";
            Data = "";
            Command = $"Get Fill level: {ColorantName}";
            try
            {
                var res = _proxyConnector.GetFillLevel(ColorantName);
                Errors = res.Error;
                Data = $"{res.Data}";
            }
            catch (Exception ex)
            {
                Errors = $"C# exception: {ex.Message}";
            }
        }
    }
}