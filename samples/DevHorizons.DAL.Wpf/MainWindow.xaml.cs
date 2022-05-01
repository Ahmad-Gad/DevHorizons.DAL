namespace DevHorizons.DAL.Wpf
{
    using System;
    using System.Configuration;
    using System.Windows;
    using DAL.Interfaces;
    using Services;
    using Sql;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICommand sqlCmd;
        public MainWindow()
        {
            InitializeComponent();

            var idataSettings = new DataAccessSettings
            {
                ConnectionSettings = new ConnectionSettings
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString
                },
                CryptographySettings = new Cryptography.CryptographySettings
                {
                    SymmetricEncryption = new Cryptography.SymmetricEncryption
                    {
                        DefaultEncryptionType = Cryptography.EncryptionType.Deterministic,
                        Deterministic = new Cryptography.SymmetricEncryptionSettings
                        {
                            EncryptionKey = "P@$$word"
                        },
                        Randomized = new Cryptography.SymmetricEncryptionSettings
                        {
                            EncryptionKey = "P@$$word"
                        }
                    },
                    Hashing = new Cryptography.HashingSettings
                    {
                        HashKey = "123456"
                    }
                }
            };

            this.sqlCmd = new SqlCommand(idataSettings);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var userService = new UserService(this.sqlCmd);
            var users = userService.GetAllUsers().Result;
            this.dgUsers.ItemsSource = users;
        }
    }
}
