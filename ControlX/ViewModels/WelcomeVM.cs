using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using System.Windows.Input;

namespace ControlX.ViewModels
{
    public class WelcomeVM: BaseViewModel
    {

        public ICommand LoginCommand { get; set; }
        public WelcomeVM(Page curPage, INavigation navigation) : base(curPage, navigation)
        {
            LoginCommand = new Command(OnLoginCommand);
        }

        private async void OnLoginCommand(object obj)
        {
            try
            {
                IsRunning = true;
                Error = string.Empty;
                var ritorno = await Orchestrator.Login(UserName, Password);
                if (ritorno != null)
                {
                    await Navigation.PushAsync(new Views.ElencoContattiV());
                }
                else
                    throw new Exception(ErrUsernameOrPasswordNotValid);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            finally
            {
                IsRunning = false;
            }

        }

        public string UserName { get; set; }
        public string Password { get; set; }



    }
}
