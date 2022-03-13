﻿using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Unigram.Controls
{
    public enum PaneToggleButtonVisibility
    {
        Visible,
        Collapsed,
        Back
    }

    public class NavigationView : ContentControl
    {
        private GlyphButton TogglePaneButton;
        private SplitView RootSplitView;

        public NavigationView()
        {
            DefaultStyleKey = typeof(NavigationView);
        }

        protected override void OnApplyTemplate()
        {
            TogglePaneButton = GetTemplateChild("TogglePaneButton") as GlyphButton;
            RootSplitView = GetTemplateChild("RootSplitView") as SplitView;

            TogglePaneButton.Click += Toggle_Click;

            RootSplitView.PaneOpening += OnPaneOpening;
            RootSplitView.PaneClosing += OnPaneClosing;
        }

        private void Toggle_Click(object sender, RoutedEventArgs e)
        {
            BackRequested?.Invoke(this, null);
        }

        private void OnPaneOpening(SplitView sender, object args)
        {
            PaneOpening?.Invoke(sender, args);
        }

        private void OnPaneClosing(SplitView sender, SplitViewPaneClosingEventArgs args)
        {
            PaneClosing?.Invoke(sender, args);
        }

        public event TypedEventHandler<NavigationView, object> BackRequested;

        public event TypedEventHandler<SplitView, object> PaneOpening;
        public event TypedEventHandler<SplitView, SplitViewPaneClosingEventArgs> PaneClosing;

        #region IsPaneOpen

        public bool IsPaneOpen
        {
            get => (bool)GetValue(IsPaneOpenProperty);
            set => SetValue(IsPaneOpenProperty, value);
        }

        public static readonly DependencyProperty IsPaneOpenProperty =
            DependencyProperty.Register("IsPaneOpen", typeof(bool), typeof(NavigationView), new PropertyMetadata(false));

        #endregion

        #region PaneHeader

        public object PaneHeader
        {
            get => GetValue(PaneHeaderProperty);
            set => SetValue(PaneHeaderProperty, value);
        }

        public static readonly DependencyProperty PaneHeaderProperty =
            DependencyProperty.Register("PaneHeader", typeof(object), typeof(NavigationView), new PropertyMetadata(null));

        #endregion

        #region PaneFooter

        public object PaneFooter
        {
            get => GetValue(PaneFooterProperty);
            set => SetValue(PaneFooterProperty, value);
        }

        public static readonly DependencyProperty PaneFooterProperty =
            DependencyProperty.Register("PaneFooter", typeof(object), typeof(NavigationView), new PropertyMetadata(null));

        #endregion

        #region PaneToggleButtonVisibility

        public PaneToggleButtonVisibility PaneToggleButtonVisibility
        {
            get => (PaneToggleButtonVisibility)GetValue(PaneToggleButtonVisibilityProperty);
            set => SetValue(PaneToggleButtonVisibilityProperty, value);
        }

        public static readonly DependencyProperty PaneToggleButtonVisibilityProperty =
            DependencyProperty.Register("PaneToggleButtonVisibility", typeof(PaneToggleButtonVisibility), typeof(NavigationView), new PropertyMetadata(PaneToggleButtonVisibility.Visible, OnPaneToggleButtonVisibilityChanged));

        private static void OnPaneToggleButtonVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((NavigationView)d).OnPaneToggleButtonVisibilityChanged((PaneToggleButtonVisibility)e.NewValue, (PaneToggleButtonVisibility)e.OldValue);
        }

        private void OnPaneToggleButtonVisibilityChanged(PaneToggleButtonVisibility newValue, PaneToggleButtonVisibility oldValue)
        {
            if (TogglePaneButton == null)
            {
                return;
            }

            if (newValue != PaneToggleButtonVisibility.Back)
            {
                TogglePaneButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                TogglePaneButton.Visibility = Visibility.Visible;
            }
        }

        #endregion
    }
}
