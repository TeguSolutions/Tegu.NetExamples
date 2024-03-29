﻿using Tegu.Net.Client.Maui.Pages;
using MainPage = Tegu.Net.Client.Maui.Pages.Public.MainPage;

namespace Tegu.Net.Client.Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(ControlsPage), typeof(ControlsPage));
        //Routing.RegisterRoute(nameof(MVVMOnePage), typeof(MVVMOnePage));
        //Routing.RegisterRoute(nameof(MVVMTwoPage), typeof(MVVMTwoPage));
    }
}