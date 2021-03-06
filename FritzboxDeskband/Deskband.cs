﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CSDeskBand;
using CSDeskBand.ContextMenu;

namespace FritzboxDeskband
{
    /// <summary>
    /// Example WPF deskband. Shows taskbar info capabilities and context menus
    /// </summary>
    [ComVisible(true)]
    [Guid("89BF6B36-A0B0-4C95-A666-87A55C226982")]
    [CSDeskBandRegistration(Name = "Fritzbox Widget")]
    public class Deskband : CSDeskBandWpf
    {
        public Deskband()
        {
            var toolbarHeight = SystemParameters.PrimaryScreenHeight - SystemParameters.FullPrimaryScreenHeight - SystemParameters.WindowCaptionHeight;
            DeskBandSize size = new DeskBandSize(100, -1);
            Options.MinHorizontalSize = size;
        }

        protected override UIElement UIElement => new FritzboxTaskbarElement();


    }
}
