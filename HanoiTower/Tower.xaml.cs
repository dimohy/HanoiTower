using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HanoiTower
{
    public sealed partial class Tower : UserControl
    {
        private static readonly Brush DiskColor = new SolidColorBrush(Colors.Orange);

        public int DiscCount
        {
            get => diskStack.Children.Count;
            set
            {
                SetDiscs(value);
            }
        }

        public Tower()
        {
            this.InitializeComponent();
        }

        public void SetDiscs(int count)
        {
            ClearDiscs();
            for (var n = count; n > 0; n--)
                PushDisc(n);
        }

        public void ClearDiscs()
        {
            diskStack.Children.Clear();
        }

        public void PushDisc(int size)
        {
            diskStack.Children.Insert(0, new Rectangle { Width = size * 20, Height = 10, Fill = DiskColor, Tag = size });
        }

        public int PopDisc()
        {
            if (diskStack.Children.Count is 0)
                return 0;

            var result = (int)(diskStack.Children[0] as Rectangle)!.Tag;

            diskStack.Children.RemoveAt(0);

            return result;
        }
    }
}
