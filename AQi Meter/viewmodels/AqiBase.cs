
using CommunityToolkit.Mvvm.ComponentModel;

namespace AQi_Meter.viewmodels;

public partial class AqiBase : ObservableObject
{


  

    [ObservableProperty]
    string title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(isNotBusy))]
    bool isBusy;


    public bool isNotBusy => !IsBusy;


}
