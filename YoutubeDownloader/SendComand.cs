using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    internal class SendComand
    {
        ICommand command;
        public void SetCommand(ICommand command) => this.command = command;
        public async Task Execute() => await command.Execute();
    }
}
