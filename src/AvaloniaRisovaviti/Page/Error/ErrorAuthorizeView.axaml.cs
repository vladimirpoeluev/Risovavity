using Autofac;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using InteractiveApiRisovaviti.HttpIntegration;
using System;
using System.Diagnostics;

namespace AvaloniaRisovaviti;

public partial class ErrorAuthorizeView : UserControl
{
    public ErrorAuthorizeView()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Authentication.AuthenticationUser.User = new NotAuthenticationUser();
        Process.Start(new ProcessStartInfo() { FileName = Environment.ProcessPath, UseShellExecute = true });

        var appLifetime = Application.Current?.ApplicationLifetime as Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime;
		appLifetime?.Shutdown();



	}
}