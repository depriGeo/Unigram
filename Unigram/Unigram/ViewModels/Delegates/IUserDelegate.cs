//
// Copyright Fela Ameghino 2015-2023
//
// Distributed under the GNU General Public License v3.0. (See accompanying
// file LICENSE or copy at https://www.gnu.org/licenses/gpl-3.0.txt)
//
using Telegram.Td.Api;

namespace Unigram.ViewModels.Delegates
{
    public interface IUserDelegate : IViewModelDelegate
    {
        void UpdateUser(Chat chat, User user, bool secret);
        void UpdateUserFullInfo(Chat chat, User user, UserFullInfo fullInfo, bool secret, bool accessToken);

        void UpdateUserStatus(Chat chat, User user);
    }
}
