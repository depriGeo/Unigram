//
// Copyright Fela Ameghino 2015-2023
//
// Distributed under the GNU General Public License v3.0. (See accompanying
// file LICENSE or copy at https://www.gnu.org/licenses/gpl-3.0.txt)
//
using Telegram.Td.Api;
using Unigram.Common;
using Unigram.ViewModels;
using Unigram.ViewModels.Drawers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Unigram.Selectors
{
    public class AutocompleteTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MentionTemplate { get; set; }
        public DataTemplate CommandTemplate { get; set; }
        public DataTemplate HashtagTemplate { get; set; }
        public DataTemplate StickerTemplate { get; set; }
        public DataTemplate AnimatedStickerTemplate { get; set; }
        public DataTemplate VideoStickerTemplate { get; set; }
        public DataTemplate EmojiTemplate { get; set; }
        public DataTemplate ItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is User)
            {
                return MentionTemplate;
            }
            else if (item is UserCommand)
            {
                return CommandTemplate;
            }
            else if (item is Sticker sticker)
            {
                return sticker.Format switch
                {
                    StickerFormatTgs => AnimatedStickerTemplate,
                    StickerFormatWebm => VideoStickerTemplate,
                    _ => StickerTemplate
                };
            }
            else if (item is StickerViewModel stickerViewModel)
            {
                return stickerViewModel.Format switch
                {
                    StickerFormatTgs => AnimatedStickerTemplate,
                    StickerFormatWebm => VideoStickerTemplate,
                    _ => StickerTemplate
                };
            }
            else if (item is EmojiData)
            {
                return EmojiTemplate;
            }

            return ItemTemplate ?? base.SelectTemplateCore(item, container);
        }
    }
}
