//
// Copyright Fela Ameghino 2015-2023
//
// Distributed under the GNU General Public License v3.0. (See accompanying
// file LICENSE or copy at https://www.gnu.org/licenses/gpl-3.0.txt)
//
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Shapes;

namespace Unigram.Controls
{
    public class CallToggleButton : AnimatedGlyphToggleButton
    {
        private InsetClip _visual;

        public CallToggleButton()
        {
            DefaultStyleKey = typeof(CallToggleButton);

            Checked += OnToggle;
            Unchecked += OnToggle;
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new AnimatedGlyphToggleButtonAutomationPeer(this);
        }

        protected override void OnApplyTemplate()
        {
            var presenter1 = GetTemplateChild("CrossBackground") as Path;
            var presenter2 = GetTemplateChild("CrossForeground") as Path;

            var visual1 = ElementCompositionPreview.GetElementVisual(presenter1);
            var visual2 = ElementCompositionPreview.GetElementVisual(presenter2);

            var hangup = IsChecked == true;

            _visual = visual1.Compositor.CreateInsetClip(hangup ? 20 : 0, 0, 0, 0);
            _visual.CenterPoint = new Vector2(10, 10);
            _visual.Scale = new Vector2(2);
            _visual.RotationAngleInDegrees = -45;

            visual1.Clip = _visual;
            visual2.Clip = _visual;

            base.OnApplyTemplate();
        }

        protected override void OnToggle()
        {
            base.OnToggle();
        }

        private void OnToggle(object sender, RoutedEventArgs e)
        {
            if (_visual == null)
            {
                return;
            }

            var hangup = IsChecked == true;
            if (hangup)
            {
                var left = _visual.Compositor.CreateScalarKeyFrameAnimation();
                left.InsertKeyFrame(0, 0);
                left.InsertKeyFrame(1, 20);
                //left.Duration = TimeSpan.FromSeconds(1);

                _visual.RightInset = 0;
                _visual.StartAnimation("LeftInset", left);
            }
            else
            {
                var right = _visual.Compositor.CreateScalarKeyFrameAnimation();
                right.InsertKeyFrame(0, 20);
                right.InsertKeyFrame(1, 0);
                //right.Duration = TimeSpan.FromSeconds(1);

                _visual.LeftInset = 0;
                _visual.StartAnimation("RightInset", right);
            }
        }
    }
}
