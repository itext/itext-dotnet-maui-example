using Microsoft.Maui.Controls;

namespace itext_dotnet_maui_example;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }
    
    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}