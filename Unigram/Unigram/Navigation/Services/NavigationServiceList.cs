//
// Copyright Fela Ameghino 2015-2023
//
// Distributed under the GNU General Public License v3.0. (See accompanying
// file LICENSE or copy at https://www.gnu.org/licenses/gpl-3.0.txt)
//
using System.Collections.Generic;
using System.Linq;

namespace Unigram.Navigation.Services
{
    public class NavigationServiceList : List<INavigationService>
    {
        public INavigationService GetByFrameId(string frameId) => this.FirstOrDefault(x => x.FrameFacade.FrameId == frameId);
        public INavigationService RemoveByFrameId(string frameId)
        {
            var service = GetByFrameId(frameId);
            if (service != null)
            {
                Remove(service);
                return service;
            }

            return null;
        }

        public void RemoveBySessionId(int session)
        {
            foreach (var service in this.ToList())
            {
                if (service.SessionId == session)
                {
                    Remove(service);
                }
            }
        }
    }
}
