using DevExpress.Mvvm;
using Discord_Chat_Cloner.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Discord_Chat_Cloner.Core
{
    public class MainWindowVM : ViewModelBase
    {
        #region Variables
        private MainWindow _window;
        #endregion
        public MainWindowVM(MainWindow window)
        {
            //Gets the mainwindow allowing us to interact with the mainwindow from the viewmodel
            this._window = window;
        }
        #region Window Controls
        public ICommand Close => new DelegateCommand(() =>
        {
            Environment.Exit(0);
        });
        public ICommand Maximized => new DelegateCommand(() =>
        {
            if (_window.WindowState == System.Windows.WindowState.Maximized)
                _window.WindowState = System.Windows.WindowState.Normal;
            else
                _window.WindowState = System.Windows.WindowState.Maximized;

        });
        public ICommand Minimized => new DelegateCommand(() =>
        {
            _window.WindowState = System.Windows.WindowState.Minimized;
        });
        #endregion
        #region Buttons
        public ICommand Cloan => new DelegateCommand(async () =>
        {
            Discord client = new Discord(_window.AuthTokenTxtbox.Text);
            string channel = _window.ChannelIdTxtbox.Text;
            List<Message> messages = new List<Message>();
            ulong? lastMessage = null;
            while (true)
            {
                var batch = await client.GetMessagesAsync(channel, 100, lastMessage);
                if (batch.Count() <= 0)
                    break;
                lastMessage = Convert.ToUInt64(batch[batch.Count-1].id);
                messages.AddRange(batch);
            }
            messages.Reverse();
            FileManager.Export(messages);
        });
        #endregion
    }
}
