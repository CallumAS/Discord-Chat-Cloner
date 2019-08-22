using Discord_Chat_Cloner.Core.DataModels;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Chat_Cloner.Core
{
    public class FileManager
    {
        public static void Export(List<Message> messages)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text File|*.txt|Json File|*.json",
                FileName = "Messages",
                Title = "Save Chats File"
            };
            if (dialog.ShowDialog() == true)
            {
                switch (dialog.FilterIndex)
                {
                    case 1:
                        System.IO.File.WriteAllText(dialog.FileName, string.Join(Environment.NewLine, messages.Select(x=> {
                            string message = $"{x.author.username}: {x.content}";
                            if (x.attachments.Count > 0)
                                message += $" | {string.Join(", ", x.attachments.Select(f => $"{f.Filename} {f.Url}"))}";
                            return message;
                            })));
                        break;
                    case 2:
                        System.IO.File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(messages, Formatting.Indented));
                        break;
                }
            }
        }
    }
}
