//
// Copyright Fela Ameghino 2015-2023
//
// Distributed under the GNU General Public License v3.0. (See accompanying
// file LICENSE or copy at https://www.gnu.org/licenses/gpl-3.0.txt)
//
namespace Unigram.ViewModels
{
    public partial class DialogViewModel
    {
        //public bool HasBots
        //{
        //    get
        //    {
        //        var user = With as TLUser;
        //        if (user != null && user.IsBot)
        //        {
        //            return true;
        //        }

        //        var channel = With as TLChannel;
        //        if (channel != null && channel.IsBroadcast)
        //        {
        //            return false;
        //        }

        //        var chat = With as TLChatBase;
        //        return chat != null && chat.BotInfo != null && chat.BotInfo.Count > 0;
        //    }
        //}

        //public bool HasBotsCommands
        //{
        //    get
        //    {
        //        var user = With as TLUser;
        //        if (user != null && user.IsBot && user.BotInfo?.Commands.Count > 0)
        //        {
        //            return true;
        //        }

        //        var channel = With as TLChannel;
        //        if (channel != null && channel.IsBroadcast)
        //        {
        //            return false;
        //        }

        //        var chat = With as TLChatBase;
        //        return chat != null && chat.BotInfo != null && chat.BotInfo.Count > 0 && chat.BotInfo.Any(x => x.Commands?.Count > 0);
        //    }
        //}

        //private async void GetFullInfo()
        //{
        //    var user = With as TLUser;
        //    if (user == null)
        //    {
        //        return;
        //    }
        //    var result = await ClientService.GetFullUserAsync(new TLInputUser { UserId = user.Id, AccessHash = user.AccessHash.Value });
        //    if (result.IsSucceeded)
        //    {
        //        var userFull = result.Result;
        //        user.Link = userFull.Link;
        //        user.ProfilePhoto = userFull.ProfilePhoto;
        //        user.NotifySettings = userFull.NotifySettings;
        //        user.IsBlocked = userFull.IsBlocked;
        //        user.BotInfo = userFull.BotInfo;
        //        //user.About = userFull.About;

        //        Dispatch(() =>
        //        {
        //            RaisePropertyChanged(() => HasBots);
        //            RaisePropertyChanged(() => With);
        //            //this.Subtitle = this.GetSubtitle();
        //        });
        //    }
        //}

        //private TLUser GetBot(TLMessage message)
        //{
        //    var user = With as TLUser;
        //    if (user == null || !user.IsBot)
        //    {
        //        user = (message.ViaBot as TLUser);
        //    }

        //    if (user == null || !user.IsBot)
        //    {
        //        var tLMessage = message as TLMessage;
        //        if (tLMessage != null)
        //        {
        //            user = (tLMessage.From as TLUser);
        //        }
        //    }

        //    return user;
        //}
    }
}
