﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LivetApp2.Views
{
    /* 
     * If some events were receive from ViewModel, then please use PropertyChangedWeakEventListener and CollectionChangedWeakEventListener.
     * If you want to subscribe custome events, then you can use LivetWeakEventListener.
     * When window closing and any timing, Dispose method of LivetCompositeDisposable is useful to release subscribing events.
     *
     * Those events are managed using WeakEventListener, so it is not occurred memory leak, but you should release explicitly.
     */
    public partial class MainWindow : Window
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private DataGridScrollSynchronizer _verticalScrollSynchronizer;
        private DataGridScrollSynchronizer _horizontalScrollSynchronizer;
        private ScrollDragger _ScrollDragger;

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods ---------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            _verticalScrollSynchronizer = new DataGridScrollSynchronizer(SynchronizeDirection.Vertical);
            _verticalScrollSynchronizer.AddScrollableElement(rowHeader1);
            _verticalScrollSynchronizer.AddScrollableElement(rowHeader2);
            _verticalScrollSynchronizer.AddScrollableElement(rowHeader3);
            _verticalScrollSynchronizer.AddScrollableElement(body);

            _horizontalScrollSynchronizer = new DataGridScrollSynchronizer(SynchronizeDirection.Horizontal);
            _horizontalScrollSynchronizer.AddScrollableElement(columnHeader1);
            _horizontalScrollSynchronizer.AddScrollableElement(columnHeader2);
            _horizontalScrollSynchronizer.AddScrollableElement(columnHeader3);
            _horizontalScrollSynchronizer.AddScrollableElement(body);

            _ScrollDragger = new ScrollDragger(body);

            ComponentDispatcher.ThreadIdle += ComponentDispatcher_ThreadIdle;
        }

        private void ComponentDispatcher_ThreadIdle(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) == true
                || Keyboard.IsKeyDown(Key.RightCtrl) == true)
            {
                ctrlDisplay.Visibility = Visibility.Visible;
            }
            else
            {
                ctrlDisplay.Visibility = Visibility.Collapsed;
            }
        }

        private void body_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) == true
                || Keyboard.IsKeyDown(Key.RightCtrl) == true)
            {
                slider.Value += (e.Delta > 0) ? -0.03 : 0.03;

                e.Handled = true;
            }
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}
