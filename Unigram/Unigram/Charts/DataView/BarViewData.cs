//
// Copyright Fela Ameghino 2015-2023
//
// Distributed under the GNU General Public License v3.0. (See accompanying
// file LICENSE or copy at https://www.gnu.org/licenses/gpl-3.0.txt)
//
using Unigram.Charts.Data;
using Windows.UI;

namespace Unigram.Charts.DataView
{
    public class BarViewData : LineViewData
    {
        public readonly Paint unselectedPaint = new Paint();

        public Color blendColor;

        public BarViewData(ChartData.Line line)
            : base(line)
        {
            //paint.setStyle(Paint.Style.STROKE);
            //unselectedPaint.setStyle(Paint.Style.STROKE);
            //paint.setAntiAlias(false);
        }

        //public void updateColors()
        //{
        //    super.updateColors();
        //}
    }
}
