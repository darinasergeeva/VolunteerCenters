namespace VolunteerCenters
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new FormLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FormEvents(
                        loginForm.CurrentUser,
                        loginForm.IsGuest,
                        loginForm.IsAdmin
                    ));
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}