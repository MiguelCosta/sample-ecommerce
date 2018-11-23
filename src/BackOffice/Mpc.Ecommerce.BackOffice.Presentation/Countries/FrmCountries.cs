using System.Windows.Forms;
using Mpc.Ecommerce.BackOffice.Application.Services.Countries;

namespace Mpc.Ecommerce.BackOffice.DesktopApp.Countries
{
    public partial class FrmCountries : Form
    {
        private ICountryService _countryService;

        public FrmCountries(ICountryService countryService)
        {
            InitializeComponent();
            _countryService = countryService;
        }

        private async void FrmCountries_Load(object sender, System.EventArgs e)
        {
            var countries = await _countryService.GetAllAsync();

            countryDtoBindingSource.DataSource = countries;
            countryDtoBindingSource.ResetBindings(false);
        }
    }
}
