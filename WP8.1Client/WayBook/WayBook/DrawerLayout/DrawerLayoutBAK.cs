using System;
using System.Linq;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace DrawerLayout
{
    public class DrawerLayoutBAK : Grid
    {
        #region Globals and events

        private readonly PropertyPath _translatePath = new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)");
        private readonly PropertyPath _colorPath = new PropertyPath("(Grid.Background).(SolidColorBrush.Color)");

        private readonly TranslateTransform _listFragmentTransform = new TranslateTransform();
        private readonly TranslateTransform _deltaTransform = new TranslateTransform();
        private const int MaxAlpha = 100;

        public delegate void DrawerEventHandler(object sender);
        public event DrawerEventHandler DrawerOpened;
        public event DrawerEventHandler DrawerClosed;

        private Storyboard _fadeInStoryboardLeft;
        private Storyboard _fadeOutStoryboardLeft;
        private Storyboard _fadeInStoryboardRight;
        private Storyboard _fadeOutStoryboardRight;
        private Grid _listLeftFragment;
        private Grid _listRightFragment;
        private Grid _mainFragment;
        private Grid _shadowFragment;

        #endregion

        #region Dependency Properties

        public bool IsDrawerOpen
        {
             get { return (bool)GetValue(IsDrawerOpenProperty); }
             set { SetValue(IsDrawerOpenProperty, value); }
        }

        public static readonly DependencyProperty IsDrawerOpenProperty = DependencyProperty.Register("IsDrawerOpen", typeof(bool), typeof(DrawerLayoutBAK), new PropertyMetadata(false));

        private PropertyPath TranslatePath
        {
            get { return _translatePath; }
        }
        private PropertyPath ColorPath
        {
            get { return _colorPath; }
        }

        #endregion

        #region Methods

        public DrawerLayoutBAK()
        {
            IsDrawerOpen = false;
        }
   
        public void InitializeDrawerLayout()
        {
            if (Children == null) return;
            if (Children.Count < 2) return;

            try
            {
                _mainFragment = Children.OfType<Grid>().FirstOrDefault();
                _listLeftFragment = Children.OfType<Grid>().ElementAt(1);
                _listRightFragment = Children.OfType<Grid>().ElementAt(2);
            }
            catch
            {
                return;
            }

            if (_mainFragment == null || _listLeftFragment == null || _listRightFragment==null) return;

            _mainFragment.Name = "_mainFragment";
            _listLeftFragment.Name = "_listLeftFragment";
            _listRightFragment.Name = "_listRightFragment";
            // _mainFragment
            _mainFragment.HorizontalAlignment = HorizontalAlignment.Stretch;
            _mainFragment.VerticalAlignment = VerticalAlignment.Stretch;
            if (_mainFragment.Background == null) _mainFragment.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

            // Render transform _listLeftFragment
            _listLeftFragment.HorizontalAlignment = HorizontalAlignment.Left;
            _listLeftFragment.VerticalAlignment = VerticalAlignment.Stretch;
            _listLeftFragment.Width = (Window.Current.Bounds.Width/3)*2;
            if (_listLeftFragment.Background == null) _listLeftFragment.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            var animatedTranslateTransform = new TranslateTransform { X = Window.Current.Bounds.Width+_listLeftFragment.Width, Y = 0 };

            _listLeftFragment.RenderTransform = animatedTranslateTransform;
            _listLeftFragment.RenderTransformOrigin = new Point(0.5, 0.5);

            _listLeftFragment.UpdateLayout();

            // Render transform _listRightFragment
            _listRightFragment.HorizontalAlignment = HorizontalAlignment.Left;
            _listRightFragment.VerticalAlignment = VerticalAlignment.Stretch;
            _listRightFragment.Width = (Window.Current.Bounds.Width / 3) * 2;
            if (_listRightFragment.Background == null) _listRightFragment.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            var animatedTranslateTransformR = new TranslateTransform { X = Window.Current.Bounds.Width + _listRightFragment.Width, Y = 0 };

            _listRightFragment.RenderTransform = animatedTranslateTransformR;
            _listRightFragment.RenderTransformOrigin = new Point(0.5, 0.5);

            _listRightFragment.UpdateLayout();

            // Create a shadow element
            _shadowFragment = new Grid
            {
                Name = "_shadowFragment",
                Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255)),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Visibility = Visibility.Collapsed
            };
            _shadowFragment.Tapped += shadowFragment_Tapped;
            _shadowFragment.IsHitTestVisible = false;

            // Set ZIndexes
            Canvas.SetZIndex(_shadowFragment, 50);
            Canvas.SetZIndex(_listLeftFragment, 51);
            Canvas.SetZIndex(_listRightFragment, 51);
            Children.Add(_shadowFragment);

            // Create a new fadeIn animation storyboard
            _fadeInStoryboardRight = new Storyboard();

            // New double animation
            var doubleAnimationR1 = new DoubleAnimation { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)), To = Window.Current.Bounds.Width/3 };

            Storyboard.SetTarget(doubleAnimationR1, _listRightFragment);
            Storyboard.SetTargetProperty(doubleAnimationR1, TranslatePath.Path);
            _fadeInStoryboardRight.Children.Add(doubleAnimationR1);

            // Create a new fadeIn animation storyboard
            _fadeInStoryboardLeft = new Storyboard();

            // New double animation
            var doubleAnimationL1 = new DoubleAnimation { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)), To = 0 };

            Storyboard.SetTarget(doubleAnimationL1, _listLeftFragment);
            Storyboard.SetTargetProperty(doubleAnimationL1, TranslatePath.Path);
            _fadeInStoryboardLeft.Children.Add(doubleAnimationL1);

            // New color animation for _shadowFragment
            var colorAnimationL1 = new ColorAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                To = Color.FromArgb(190, 0, 0, 0)
            };

            Storyboard.SetTarget(colorAnimationL1, _shadowFragment);
            Storyboard.SetTargetProperty(colorAnimationL1, ColorPath.Path);
            _fadeInStoryboardLeft.Children.Add(colorAnimationL1);

            // New color animation for _shadowFragment
            var colorAnimationR1 = new ColorAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                To = Color.FromArgb(190, 0, 0, 0)
            };

            Storyboard.SetTarget(colorAnimationR1, _shadowFragment);
            Storyboard.SetTargetProperty(colorAnimationR1, ColorPath.Path);
            _fadeInStoryboardRight.Children.Add(colorAnimationR1);

            // Create a new fadeOut animation storyboard
            _fadeOutStoryboardRight = new Storyboard();

            // New double animation
            var doubleAnimationR2 = new DoubleAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                To = Window.Current.Bounds.Width+_listRightFragment.Width
            };

            Storyboard.SetTarget(doubleAnimationR2, _listRightFragment);
            Storyboard.SetTargetProperty(doubleAnimationR2, TranslatePath.Path);
            _fadeOutStoryboardRight.Children.Add(doubleAnimationR2);

            // Create a new fadeOut animation storyboard
            _fadeOutStoryboardLeft = new Storyboard();

            // New double animation
            var doubleAnimationL2 = new DoubleAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                To = Window.Current.Bounds.Width + _listLeftFragment.Width
            };

            Storyboard.SetTarget(doubleAnimationL2, _listLeftFragment);
            Storyboard.SetTargetProperty(doubleAnimationL2, TranslatePath.Path);
            _fadeOutStoryboardLeft.Children.Add(doubleAnimationL2);


            // New color animation for _shadowFragment
            var colorAnimationL2 = new ColorAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                To = Color.FromArgb(0, 0, 0, 0)
            };

            Storyboard.SetTarget(colorAnimationL2, _shadowFragment);
            Storyboard.SetTargetProperty(colorAnimationL2, ColorPath.Path);
            _fadeOutStoryboardLeft.Children.Add(colorAnimationL2);

            // New color animation for _shadowFragment
            var colorAnimationR2 = new ColorAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                To = Color.FromArgb(0, 0, 0, 0)
            };

            Storyboard.SetTarget(colorAnimationR2, _shadowFragment);
            Storyboard.SetTargetProperty(colorAnimationR2, ColorPath.Path);
            _fadeOutStoryboardRight.Children.Add(colorAnimationR2);

            _mainFragment.ManipulationMode = ManipulationModes.All;
            _mainFragment.ManipulationStarted += mainLeftFragment_ManipulationStarted;

            _listLeftFragment.ManipulationMode = ManipulationModes.All;
            _listLeftFragment.ManipulationStarted += listLeftFragment_ManipulationStarted;

            _listRightFragment.ManipulationMode = ManipulationModes.All;
            _listRightFragment.ManipulationStarted += listRightFragment_ManipulationStarted;

        }
        public void OpenLeftDrawer()
        {
            if (_fadeInStoryboardLeft == null || _mainFragment == null || _listLeftFragment == null) return;
            _shadowFragment.Visibility = Visibility.Visible;
            _shadowFragment.IsHitTestVisible = true;
            _shadowFragment.Background = new SolidColorBrush(Color.FromArgb(MaxAlpha, 0, 0, 0));
            _fadeInStoryboardLeft.Begin();
            IsDrawerOpen = true;

            if (DrawerOpened != null)
                DrawerOpened(this);
        }
        public void CloseLeftDrawer()
        {
            if (_fadeOutStoryboardLeft == null || _mainFragment == null || _listLeftFragment == null) return;
            _fadeOutStoryboardLeft.Begin();
            _fadeOutStoryboardLeft.Completed += fadeOutStoryboard_Completed;
            IsDrawerOpen = false;

            if (DrawerClosed != null)
                DrawerClosed(this);
        }
        public void OpenRightDrawer()
        {
            if (_fadeInStoryboardRight == null || _mainFragment == null || _listRightFragment == null) return;
            _shadowFragment.Visibility = Visibility.Visible;
            _shadowFragment.IsHitTestVisible = true;
            _shadowFragment.Background = new SolidColorBrush(Color.FromArgb(MaxAlpha, 0, 0, 0));
            _fadeInStoryboardRight.Begin();
            IsDrawerOpen = true;

            if (DrawerOpened != null)
                DrawerOpened(this);
        }
        public void CloseRightDrawer()
        {
            if (_fadeOutStoryboardRight == null || _mainFragment == null || _listRightFragment == null) return;
            _fadeOutStoryboardRight.Begin();
            _fadeOutStoryboardRight.Completed += fadeOutStoryboard_Completed;
            IsDrawerOpen = false;

            if (DrawerClosed != null)
                DrawerClosed(this);
        }
        private void shadowFragment_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var shadow = new Storyboard();

            var doubleAnimation = new DoubleAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                To = -_listLeftFragment.Width
            };

            Storyboard.SetTarget(doubleAnimation, _listLeftFragment);
            Storyboard.SetTargetProperty(doubleAnimation, TranslatePath.Path);
            shadow.Children.Add(doubleAnimation);

            var colorAnimation = new ColorAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                To = Color.FromArgb(0, 0, 0, 0)
            };

            Storyboard.SetTarget(colorAnimation, _shadowFragment);
            Storyboard.SetTargetProperty(colorAnimation, ColorPath.Path);
            shadow.Children.Add(colorAnimation);

            shadow.Completed += shadow_Completed;
            shadow.Begin();
        }
        private void shadow_Completed(object sender, object e)
        {
            _shadowFragment.IsHitTestVisible = false;
            _shadowFragment.Visibility = Visibility.Collapsed;

            this.IsDrawerOpen = false;

            // raise close event
            if (DrawerClosed != null) DrawerClosed(this);
        }
        private void fadeOutStoryboard_Completed(object sender, object e)
        {
            _shadowFragment.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            _shadowFragment.Visibility = Visibility.Collapsed;
            if (DrawerClosed != null) DrawerClosed(this);
        }
        private void MoveListFragment(double left, Color color)
        {
            var s = new Storyboard();

            var doubleAnimation = new DoubleAnimation
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)),
                To = left
            };

            Storyboard.SetTarget(doubleAnimation, _listLeftFragment);
            Storyboard.SetTargetProperty(doubleAnimation, TranslatePath.Path);
            s.Children.Add(doubleAnimation);

            var colorAnimation = new ColorAnimation { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)), To = color };

            Storyboard.SetTarget(colorAnimation, _shadowFragment);
            Storyboard.SetTargetProperty(colorAnimation, ColorPath.Path);
            s.Children.Add(colorAnimation);

            s.Begin();
        }
        private void MoveShadowFragment(double left)
        {
            // Show shadow fragment
            _shadowFragment.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            _shadowFragment.Visibility = Visibility.Visible;

            // Set bg color based on current _listFragment position.
            var maxLeft = _listLeftFragment.ActualWidth;
            var currentLeft = maxLeft - left;

            var temp = Convert.ToInt32((currentLeft / maxLeft) * MaxAlpha);

            // Limit temp variable to 190 to avoid OverflowException
            if (temp > MaxAlpha) temp = MaxAlpha;

            byte alphaColorIndex;
            try
            {
                alphaColorIndex = Convert.ToByte(MaxAlpha - temp);
            }
            catch
            {
                alphaColorIndex = 0;
            }

            _shadowFragment.Background = new SolidColorBrush(Color.FromArgb(alphaColorIndex, 0, 0, 0));
        }

        #endregion

        #region List Left Fragment manipulation events

        private void listLeftFragment_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            var listWidth = _listLeftFragment.Width;
            if (!(e.Position.X >= listWidth - 100) || !(e.Position.X < listWidth)) return;
            _listLeftFragment.ManipulationDelta += listLeftFragment_ManipulationDelta;
            _listLeftFragment.ManipulationCompleted += listLeftFragment_ManipulationCompleted;
        }
        private void listLeftFragment_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (Math.Abs(e.Cumulative.Translation.X) < 0) return;
            if (e.Cumulative.Translation.X <= -_listLeftFragment.Width || e.Cumulative.Translation.X > 0)
            {
                listLeftFragment_ManipulationCompleted(this, null);
                return;
            }

            _listFragmentTransform.X = e.Cumulative.Translation.X;
            _listLeftFragment.RenderTransform = _listFragmentTransform;
            MoveShadowFragment(e.Cumulative.Translation.X + _listLeftFragment.Width);
        }
        private void listLeftFragment_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            // Get left of _listFragment
            var transform = (TranslateTransform)_listLeftFragment.RenderTransform;
            if (transform == null) return;
            var left = transform.X;

            // Set snap divider to 1/3 of _mainFragment width
            var snapLimit = _mainFragment.ActualWidth / 3;

            // Get init position of _listFragment
            const int initialPosition = 0;

            // If current left coordinate is smaller than snap limit, close drawer
            if (Math.Abs(initialPosition - left) > snapLimit)
            {
                MoveListFragment(-_listLeftFragment.Width, Color.FromArgb(0, 0, 0, 0));
                _shadowFragment.Visibility = Visibility.Collapsed;
                _shadowFragment.IsHitTestVisible = false;

                _listLeftFragment.ManipulationDelta -= listLeftFragment_ManipulationDelta;
                _listLeftFragment.ManipulationCompleted -= listLeftFragment_ManipulationCompleted;
                IsDrawerOpen = false;

                // raise DrawerClosed event
                if (DrawerClosed != null) DrawerClosed(this);
            }
            // else open drawer
            else if (Math.Abs(initialPosition - left) < snapLimit)
            {
                // move drawer to zero
                MoveListFragment(0, Color.FromArgb(190, 0, 0, 0));
                _shadowFragment.Visibility = Visibility.Visible;
                _shadowFragment.IsHitTestVisible = true;
                _listLeftFragment.ManipulationDelta -= listLeftFragment_ManipulationDelta;
                _listLeftFragment.ManipulationCompleted -= listLeftFragment_ManipulationCompleted;
                IsDrawerOpen = true;

                // raise Drawer_Open event
                if (DrawerOpened != null) DrawerOpened(this);
            }
        }

        #endregion


        #region List Right Fragment manipulation events

        private void listRightFragment_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            var listWidth = _listRightFragment.Width;
            if (!(e.Position.X >= listWidth - 100) || !(e.Position.X < listWidth)) return;
            _listRightFragment.ManipulationDelta += listRightFragment_ManipulationDelta;
            _listRightFragment.ManipulationCompleted += listRightFragment_ManipulationCompleted;
        }
        private void listRightFragment_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (Math.Abs(e.Cumulative.Translation.X) < 0) return;
            if (e.Cumulative.Translation.X <= -_listRightFragment.Width || e.Cumulative.Translation.X > 0)
            {
                listRightFragment_ManipulationCompleted(this, null);
                return;
            }

            _listFragmentTransform.X = e.Cumulative.Translation.X;
            _listRightFragment.RenderTransform = _listFragmentTransform;
            MoveShadowFragment(e.Cumulative.Translation.X + _listRightFragment.Width);
        }
        private void listRightFragment_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            // Get left of _listFragment
            var transform = (TranslateTransform)_listRightFragment.RenderTransform;
            if (transform == null) return;
            var left = transform.X;

            // Set snap divider to 1/3 of _mainFragment width
            var snapLimit = _mainFragment.ActualWidth / 3;

            // Get init position of _listFragment
            const int initialPosition = 0;

            // If current left coordinate is smaller than snap limit, close drawer
            if (Math.Abs(initialPosition - left) > snapLimit)
            {
                MoveListFragment(-_listRightFragment.Width, Color.FromArgb(0, 0, 0, 0));
                _shadowFragment.Visibility = Visibility.Collapsed;
                _shadowFragment.IsHitTestVisible = false;

                _listRightFragment.ManipulationDelta -= listRightFragment_ManipulationDelta;
                _listRightFragment.ManipulationCompleted -= listRightFragment_ManipulationCompleted;
                IsDrawerOpen = false;

                // raise DrawerClosed event
                if (DrawerClosed != null) DrawerClosed(this);
            }
            // else open drawer
            else if (Math.Abs(initialPosition - left) < snapLimit)
            {
                // move drawer to zero
                MoveListFragment(0, Color.FromArgb(190, 0, 0, 0));
                _shadowFragment.Visibility = Visibility.Visible;
                _shadowFragment.IsHitTestVisible = true;
                _listRightFragment.ManipulationDelta -= listRightFragment_ManipulationDelta;
                _listRightFragment.ManipulationCompleted -= listRightFragment_ManipulationCompleted;
                IsDrawerOpen = true;

                // raise Drawer_Open event
                if (DrawerOpened != null) DrawerOpened(this);
            }
        }

        #endregion



        #region Main Left fragment manipulation events

        private void mainLeftFragment_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            // If the user has the first touch on the left side of canvas, that means he's trying to swipe the drawer
            if (!(e.Position.X <= 40)) return;

            // Manipulation can be allowed
            _mainFragment.ManipulationDelta += mainLeftFragment_ManipulationDelta;
            _mainFragment.ManipulationCompleted += mainLeftFragment_ManipulationCompleted;
        }
        private void mainLeftFragment_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (Math.Abs(e.Cumulative.Translation.X) < 0) return;
            if (e.Cumulative.Translation.X >= _listLeftFragment.Width || e.Cumulative.Translation.X >= _listRightFragment.Width)
            {
                mainLeftFragment_ManipulationCompleted(this, null);
                return;
            }

            _deltaTransform.X = -_listLeftFragment.Width + e.Cumulative.Translation.X;
            _listLeftFragment.RenderTransform = _deltaTransform;

            _deltaTransform.X = -_listRightFragment.Width + e.Cumulative.Translation.X;
            _listRightFragment.RenderTransform = _deltaTransform;


            MoveShadowFragment(e.Cumulative.Translation.X);
        }
        private void mainLeftFragment_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            // Get left of _listFragment
            var transform = (TranslateTransform)_listLeftFragment.RenderTransform;
            if (transform == null) return;
            var left = transform.X;

            // Set snap divider to 1/3 of _mainFragment width
            var snapLimit = _mainFragment.ActualWidth / 3;

            // Get init position of _listFragment
            var initialPosition = -_listLeftFragment.Width;

            // If current left coordinate is smaller than snap limit, close drawer
            if (Math.Abs(initialPosition - left) < snapLimit)
            {
                MoveListFragment(initialPosition, Color.FromArgb(0, 0, 0, 0));
                _shadowFragment.Visibility = Visibility.Collapsed;
                _shadowFragment.IsHitTestVisible = false;

                _mainFragment.ManipulationDelta -= mainLeftFragment_ManipulationDelta;
                _mainFragment.ManipulationCompleted -= mainLeftFragment_ManipulationCompleted;
                IsDrawerOpen = false;

                // raise DrawerClosed event
                if (DrawerClosed != null) DrawerClosed(this);
            }
            // else open drawer
            else if (Math.Abs(initialPosition - left) > snapLimit)
            {
                // move drawer to zero
                MoveListFragment(0, Color.FromArgb(190, 0, 0, 0));
                _shadowFragment.Visibility = Visibility.Visible;
                _shadowFragment.IsHitTestVisible = true;
                _mainFragment.ManipulationDelta -= mainLeftFragment_ManipulationDelta;
                _mainFragment.ManipulationCompleted -= mainLeftFragment_ManipulationCompleted;
                IsDrawerOpen = true;

                // raise DrawerClosed event
                if (DrawerOpened != null) DrawerOpened(this);
            }
        }

        #endregion

        #region Main Right fragment manipulation events

        private void mainRightFragment_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            // If the user has the first touch on the left side of canvas, that means he's trying to swipe the drawer
            if (!(e.Position.X <= 40)) return;

            // Manipulation can be allowed
            _mainFragment.ManipulationDelta += mainRightFragment_ManipulationDelta;
            _mainFragment.ManipulationCompleted += mainRightFragment_ManipulationCompleted;
        }
        private void mainRightFragment_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (Math.Abs(e.Cumulative.Translation.X) < 0) return;
            if (e.Cumulative.Translation.X >= _listRightFragment.Width)
            {
                mainRightFragment_ManipulationCompleted(this, null);
                return;
            }

            _deltaTransform.X = -_listRightFragment.Width + e.Cumulative.Translation.X;
            _listRightFragment.RenderTransform = _deltaTransform;
            MoveShadowFragment(e.Cumulative.Translation.X);
        }
        private void mainRightFragment_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            // Get left of _listFragment
            var transform = (TranslateTransform)_listRightFragment.RenderTransform;
            if (transform == null) return;
            var left = transform.X;

            // Set snap divider to 1/3 of _mainFragment width
            var snapLimit = _mainFragment.ActualWidth / 3;

            // Get init position of _listFragment
            var initialPosition = -_listRightFragment.Width;

            // If current left coordinate is smaller than snap limit, close drawer
            if (Math.Abs(initialPosition - left) < snapLimit)
            {
                MoveListFragment(initialPosition, Color.FromArgb(0, 0, 0, 0));
                _shadowFragment.Visibility = Visibility.Collapsed;
                _shadowFragment.IsHitTestVisible = false;

                _mainFragment.ManipulationDelta -= mainRightFragment_ManipulationDelta;
                _mainFragment.ManipulationCompleted -= mainRightFragment_ManipulationCompleted;
                IsDrawerOpen = false;

                // raise DrawerClosed event
                if (DrawerClosed != null) DrawerClosed(this);
            }
            // else open drawer
            else if (Math.Abs(initialPosition - left) > snapLimit)
            {
                // move drawer to zero
                MoveListFragment(0, Color.FromArgb(190, 0, 0, 0));
                _shadowFragment.Visibility = Visibility.Visible;
                _shadowFragment.IsHitTestVisible = true;
                _mainFragment.ManipulationDelta -= mainRightFragment_ManipulationDelta;
                _mainFragment.ManipulationCompleted -= mainRightFragment_ManipulationCompleted;
                IsDrawerOpen = true;

                // raise DrawerClosed event
                if (DrawerOpened != null) DrawerOpened(this);
            }
        }

        #endregion


    }
}