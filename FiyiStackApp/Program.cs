namespace FiyiStackApp
{
    internal static class Program
    {
        public static WinFormConfigurationComponent WinFormConfigurationComponent { get; set; } = new WinFormConfigurationComponent();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}