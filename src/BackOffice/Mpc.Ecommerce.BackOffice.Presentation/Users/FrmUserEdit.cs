using System.Windows.Forms;
using Mpc.Ecommerce.BackOffice.Application.Dto;
using Mpc.Ecommerce.BackOffice.Application.Services.Users;

namespace Mpc.Ecommerce.BackOffice.DesktopApp.Users
{
    public partial class FrmUserEdit : Form
    {
        private IUserService _userService;

        public FrmUserEdit(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void BtnSave_ClickAsync(object sender, System.EventArgs e)
        {
            var user = new UserDto
            {
                Email = TxtEmail.Text,
                Name = TxtName.Text,
                Password = TxtPassword.Text,
                Username = TxtUsername.Text
            };

            await _userService.CreateAsync(user).ConfigureAwait(false);

            MessageBox.Show("User created");
        }
    }
}
